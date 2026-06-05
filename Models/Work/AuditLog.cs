using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreKeeper.Data.Models.Work
{
    public class AuditLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.Now;

        [Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Action { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Details { get; set; }

        public int? InvoiceId { get; set; }

        public string? OldValuesJson { get; set; }
        public string? NewValuesJson { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        public virtual Invoice? Invoice { get; set; }
    }
}