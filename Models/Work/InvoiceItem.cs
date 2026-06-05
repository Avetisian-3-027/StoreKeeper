using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreKeeper.Data.Models.Work
{
    public class InvoiceItem
    {
        [Key]
        public int Id { get; set; }

        public int InvoiceId { get; set; }
        [ForeignKey(nameof(InvoiceId))]
        public virtual Invoice? Invoice { get; set; }

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerKg { get; set; }
    }
}