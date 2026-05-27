namespace StoreKeeper.Data.Permissions
{
    public static class AppPermissions
    {
        public const string ViewProducts = "ViewProducts";
        public const string EditProducts = "EditProducts";
        public const string DeleteProducts = "DeleteProducts";

        public const string ViewDishes = "ViewDishes";
        public const string EditDishes = "EditDishes";
        public const string DeleteDishes = "DeleteDishes";

        public const string CreateInvoices = "CreateInvoices";
        public const string PrintInvoices = "PrintInvoices";

        public const string ManageUsers = "ManageUsers";
        public const string ViewLogs = "ViewLogs";

        public static string[] GetAllPermissions()
        {
            return new[]
            {
                ViewProducts, EditProducts, DeleteProducts,
                ViewDishes, EditDishes, DeleteDishes,
                CreateInvoices, PrintInvoices,
                ManageUsers, ViewLogs
            };
        }

        public static Dictionary<string, string> GetLocalizedNames()
        {
            return new Dictionary<string, string>
            {
                { ViewProducts, "Перегляд товарів" },
                { EditProducts, "Редагування товарів" },
                { DeleteProducts, "Видалення товарів" },
                { ViewDishes, "Перегляд страв" },
                { EditDishes, "Редагування страв" },
                { DeleteDishes, "Видалення страв" },
                { CreateInvoices, "Створення накладних (прихід/розхід)" },
                { PrintInvoices, "Друк накладних" },
                { ManageUsers, "Керування користувачами та ролями" },
                { ViewLogs, "Перегляд журналу логів" }
            };
        }
    }
}