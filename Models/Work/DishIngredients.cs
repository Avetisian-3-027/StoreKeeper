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

        // Початок дії (включно). Якщо null – означає "від початку часів"
        public DateTime? StartDate { get; set; }

        // Кінець дії (включно). Якщо null – означає "до безкінечності"
        public DateTime? EndDate { get; set; }

        // Грами брутто на одну порцію (з точністю до 0.01 г, але на практиці використовуємо 0.1 г)
        [Column(TypeName = "decimal(8,2)")]
        public decimal GramsBrutto { get; set; }

        // Метод перевірки, чи діє запис на задану дату
        public bool IsActiveOnDate(DateTime date)
        {
            if (StartDate.HasValue && date.Date < StartDate.Value.Date)
                return false;
            if (EndDate.HasValue && date.Date > EndDate.Value.Date)
                return false;
            return true;
        }
    }
}