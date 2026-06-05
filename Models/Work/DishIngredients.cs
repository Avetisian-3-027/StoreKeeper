using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreKeeper.Data.Models.Work
{
    public class DishIngredient
    {
        [Key]
        public int Id { get; set; }

        public int DishId { get; set; }
        [ForeignKey(nameof(DishId))]
        public virtual Dish? Dish { get; set; }

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product { get; set; }

        // Початок дії (зберігається дата, але використовується тільки місяць/день, рік фіксований 2000)
        public DateTime? StartDate { get; set; }

        // Кінець дії (рік теж 2000)
        public DateTime? EndDate { get; set; }

        // Грами брутто на одну порцію
        [Column(TypeName = "decimal(8,2)")]
        public decimal GramsBrutto { get; set; }

        // Метод перевірки, чи діє інгредієнт на задану дату (з урахуванням тільки дня/місяця)
        public bool IsDateInRange(DateTime date)
        {
            // Якщо період не задано – глобальний
            if (!StartDate.HasValue || !EndDate.HasValue)
                return true;

            // Приводимо дату до фіксованого року 2000
            var target = new DateTime(2000, date.Month, date.Day);
            var start = new DateTime(2000, StartDate.Value.Month, StartDate.Value.Day);
            var end = new DateTime(2000, EndDate.Value.Month, EndDate.Value.Day);

            if (start <= end)
            {
                // Простий інтервал
                return target >= start && target <= end;
            }
            else
            {
                // Інтервал через Новий рік (наприклад, 20.12 – 10.01)
                return target >= start || target <= end;
            }
        }
    }
}