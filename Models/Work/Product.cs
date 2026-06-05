using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreKeeper.Data.Models.Work
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public virtual Category? Category { get; set; }

        // Кількість на складі в кг (з точністю до 1 грама = 0.001 кг)
        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; } = 0;

        // Поточна ціна за кг
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerKg { get; set; } = 0;

        // Вартість запасів на складі = Quantity * PricePerKg (обчислюване поле в коді)
        [NotMapped]
        public decimal TotalValue => Quantity * PricePerKg;
    }
}   