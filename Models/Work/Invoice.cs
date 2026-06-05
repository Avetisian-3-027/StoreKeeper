using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreKeeper.Data.Models.Work
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public int Type { get; set; } // 1 - прихід, 2 - розхід

        [Required, MaxLength(20)]
        public string Number { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Comment { get; set; }

        [MaxLength(200)]
        public string? Supplier { get; set; } // Постачальник (тільки для приходу)

        public int? UserId { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}