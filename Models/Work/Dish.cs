using System.ComponentModel.DataAnnotations;

namespace StoreKeeper.Data.Models.Work
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string TechMapNumber { get; set; } = string.Empty; // 1.1, 4.16 тощо

        [Required, MaxLength(150)]
        public string Name { get; set; } = string.Empty;
    }
}