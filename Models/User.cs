using System.ComponentModel.DataAnnotations;

namespace StoreKeeper.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        // null = пароль не потрібен
        public string? PasswordHash { get; set; }

        // Спеціальний прапор, який дає всі права (адмін)
        public bool IsAdmin { get; set; }

        // Окремі дозволи (тільки якщо IsAdmin == false)
        public bool CanViewProducts { get; set; }
        public bool CanEditProducts { get; set; }
        public bool CanDeleteProducts { get; set; }

        public bool CanViewDishes { get; set; }
        public bool CanEditDishes { get; set; }
        public bool CanDeleteDishes { get; set; }

        public bool CanCreateInvoices { get; set; }      // Прихід/розхід
        public bool CanPrintInvoices { get; set; }

        public bool CanManageRoles { get; set; }         // Керування ролями/користувачами
        public bool CanViewLogs { get; set; }

        // Метод перевірки права
        public bool HasPermission(Func<User, bool> permissionCheck)
        {
            if (IsAdmin) return true;
            return permissionCheck(this);
        }
    }
}