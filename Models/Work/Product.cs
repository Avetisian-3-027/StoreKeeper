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

        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerKg { get; set; } = 0;

        [NotMapped]
        public decimal TotalValue => Quantity * PricePerKg;
    }
}   