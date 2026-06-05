using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        // Тільки ID вибраної бази даних (з таблиці Databases)
        public int? SelectedDatabaseId { get; set; }

        [ForeignKey(nameof(SelectedDatabaseId))]
        public virtual DatabaseRecord? SelectedDatabase { get; set; }

        // Методи для роботи з правами (без змін)
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
}