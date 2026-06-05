using System;
using System.Text.Json;
using StoreKeeper.Data.DbContext;
using StoreKeeper.Data.Models.Work;

namespace StoreKeeper.WinForms.Services
{
    public static class AuditService
    {
        public static void Log(WorkDbContext context, string username, string action, string details = null, int? invoiceId = null, object oldValues = null, object newValues = null)
        {
            var log = new AuditLog
            {
                Timestamp = DateTime.Now,
                Username = username,
                Action = action,
                Details = details,
                InvoiceId = invoiceId,
                OldValuesJson = oldValues == null ? null : JsonSerializer.Serialize(oldValues),
                NewValuesJson = newValues == null ? null : JsonSerializer.Serialize(newValues)
            };
            context.AuditLogs.Add(log);
            context.SaveChanges();
        }
    }
}