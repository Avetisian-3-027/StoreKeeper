using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace StoreKeeper.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        public string? PasswordHash { get; set; }

        public bool IsAdmin { get; set; }

        public string? PermissionsList { get; set; }

        // JSON-рядок з конфігурацією БД (зберігається в БД)
        public string? DatabaseConfigJson { get; set; }

        // Властивість, яка не мапується в БД, використовується для зручності
        [NotMapped]
        public DatabaseConfig DatabaseConfig
        {
            get
            {
                if (string.IsNullOrWhiteSpace(DatabaseConfigJson))
                    return new DatabaseConfig { Provider = "SQLite", FolderPath = GetDefaultFolderPath() };
                return JsonSerializer.Deserialize<DatabaseConfig>(DatabaseConfigJson) ?? new DatabaseConfig();
            }
            set
            {
                DatabaseConfigJson = JsonSerializer.Serialize(value);
            }
        }

        // Допоміжний метод для отримання шляху за замовчуванням
        private string GetDefaultFolderPath()
        {
            string safeName = string.IsNullOrEmpty(Username) ? "user" : Username.Replace(' ', '_');
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(docPath, "StoreKeeper", "DataBases", safeName);
        }

        // Методи для роботи з правами
        public bool HasPermission(string permission)
        {
            if (IsAdmin) return true;
            if (string.IsNullOrWhiteSpace(PermissionsList)) return false;
            var permissions = PermissionsList.Split(',')
                .Select(p => p.Trim())
                .Where(p => !string.IsNullOrEmpty(p));
            return permissions.Contains(permission);
        }

        public void SetPermissions(IEnumerable<string> permissions)
        {
            PermissionsList = string.Join(",", permissions.Where(p => !string.IsNullOrWhiteSpace(p)));
        }

        public string[] GetPermissionsArray()
        {
            if (string.IsNullOrWhiteSpace(PermissionsList)) return new string[0];
            return PermissionsList.Split(',').Select(p => p.Trim()).ToArray();
        }
    }

    // Клас конфігурації бази даних
    public class DatabaseConfig
    {
        public string Provider { get; set; } = "SQLite"; // SQLite, MySQL, PostgreSQL

        // Для SQLite
        public string? FolderPath { get; set; }

        // Для MySQL/PostgreSQL
        public string? Server { get; set; }
        public string? Port { get; set; }
        public string? DatabaseName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        // Отримання готового рядка підключення
        public string GetConnectionString()
        {
            if (Provider == "SQLite")
            {
                string folder = string.IsNullOrWhiteSpace(FolderPath)
                    ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "StoreKeeper", "DataBases", "default")
                    : FolderPath;
                Directory.CreateDirectory(folder);
                string dbPath = Path.Combine(folder, "storekeeper.db");
                return $"Data Source={dbPath}";
            }
            else if (Provider == "MySQL")
            {
                string server = string.IsNullOrEmpty(Server) ? "localhost" : Server;
                string port = string.IsNullOrEmpty(Port) ? "3306" : Port;
                string db = string.IsNullOrEmpty(DatabaseName) ? "storekeeper" : DatabaseName;
                string uid = Username ?? "root";
                string pwd = Password ?? "";
                return $"Server={server};Port={port};Database={db};Uid={uid};Pwd={pwd};";
            }
            else if (Provider == "PostgreSQL")
            {
                string host = string.IsNullOrEmpty(Server) ? "localhost" : Server;
                string port = string.IsNullOrEmpty(Port) ? "5432" : Port;
                string db = string.IsNullOrEmpty(DatabaseName) ? "storekeeper" : DatabaseName;
                string user = Username ?? "postgres";
                string pwd = Password ?? "";
                return $"Host={host};Port={port};Database={db};Username={user};Password={pwd};";
            }
            return "";
        }
    }
}