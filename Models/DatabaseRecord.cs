using Microsoft.Data.Sqlite;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.IO;

namespace StoreKeeper.Data.Models
{
    public class DatabaseRecord
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public string? FolderPath { get; set; }

        [Required, MaxLength(100)]
        public string? FileName { get; set; } = "storekeeper.db";

        public bool IsEncrypted { get; set; }
        public string? KeyFilePath { get; set; }

        public string FullPath => string.IsNullOrEmpty(FolderPath) ? "" : Path.Combine(FolderPath, FileName ?? "storekeeper.db");

        public void CreateEmptyDatabase()
        {
            if (string.IsNullOrWhiteSpace(FolderPath) || string.IsNullOrWhiteSpace(FileName)) return;
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            var csBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = FullPath,
                Mode = SqliteOpenMode.ReadWriteCreate
            };
            if (IsEncrypted && !string.IsNullOrEmpty(KeyFilePath))
            {
                if (!File.Exists(KeyFilePath))
                {
                    string key = GenerateRandomKey();
                    File.WriteAllText(KeyFilePath, key);
                }
                string keyContent = File.ReadAllText(KeyFilePath);
                csBuilder.Password = keyContent;
            }
            using (var connection = new SqliteConnection(csBuilder.ToString()))
            {
                connection.Open();
            }
        }

        private string GenerateRandomKey()
        {
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                byte[] bytes = new byte[32];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }

        public string GetConnectionString()
        {
            if (string.IsNullOrWhiteSpace(FolderPath) || string.IsNullOrWhiteSpace(FileName))
                throw new InvalidOperationException("FolderPath or FileName not set");
            var csBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = FullPath,
                Mode = SqliteOpenMode.ReadWrite
            };
            if (IsEncrypted && File.Exists(KeyFilePath))
            {
                string key = File.ReadAllText(KeyFilePath);
                csBuilder.Password = key;
            }
            return csBuilder.ToString();
        }

        public DatabaseRecord EncryptCopy(string newFolderPath, string newKeyFilePath, string newFileName = null)
        {
            if (IsEncrypted)
                throw new InvalidOperationException("База вже зашифрована.");

            Directory.CreateDirectory(newFolderPath);
            string newDbPath = Path.Combine(newFolderPath, newFileName ?? FileName ?? "storekeeper.db");
            string encryptionKey = GenerateRandomKey();
            File.WriteAllText(newKeyFilePath, encryptionKey);

            var newCsBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = newDbPath,
                Mode = SqliteOpenMode.ReadWriteCreate,
                Password = encryptionKey
            };
            using (var newConn = new SqliteConnection(newCsBuilder.ToString()))
            {
                newConn.Open();
                string oldConnString = GetConnectionString();
                using (var oldConn = new SqliteConnection(oldConnString))
                {
                    oldConn.Open();
                    var tables = new List<string>();
                    using (var cmd = oldConn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%'";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                tables.Add(reader.GetString(0));
                        }
                    }

                    foreach (var table in tables)
                    {
                        string createSql;
                        using (var cmd = oldConn.CreateCommand())
                        {
                            cmd.CommandText = $"SELECT sql FROM sqlite_master WHERE type='table' AND name='{table}'";
                            createSql = cmd.ExecuteScalar() as string;
                        }
                        if (string.IsNullOrEmpty(createSql)) continue;

                        using (var cmd = newConn.CreateCommand())
                        {
                            cmd.CommandText = createSql;
                            cmd.ExecuteNonQuery();
                        }

                        using (var cmdRead = oldConn.CreateCommand())
                        {
                            cmdRead.CommandText = $"SELECT * FROM [{table}]";
                            using (var reader = cmdRead.ExecuteReader())
                            {
                                var schema = reader.GetColumnSchema();
                                string columns = string.Join(", ", schema.Select(c => $"[{c.ColumnName}]"));
                                string parameters = string.Join(", ", schema.Select(c => $"@{c.ColumnName}"));

                                using (var cmdInsert = newConn.CreateCommand())
                                {
                                    cmdInsert.CommandText = $"INSERT INTO [{table}] ({columns}) VALUES ({parameters})";
                                    foreach (var col in schema)
                                        cmdInsert.Parameters.Add(new SqliteParameter($"@{col.ColumnName}", col.DataType));
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < schema.Count; i++)
                                            cmdInsert.Parameters[i].Value = reader[i];
                                        cmdInsert.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return new DatabaseRecord
            {
                Name = this.Name,
                FolderPath = newFolderPath,
                FileName = newFileName ?? FileName,
                IsEncrypted = true,
                KeyFilePath = newKeyFilePath
            };
        }
    }
}