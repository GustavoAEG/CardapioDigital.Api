using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace CardapioDigital.Domain.Entities
{
    public class DailySpecial
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid RestaurantId { get; private set; }
        public Guid MenuItemId { get; private set; }
        public DateOnly Date { get; private set; }
        public string? HighlightText { get; private set; }

        // Navegação
        public Restaurant Restaurant { get; private set; } = null!;
        public MenuItem MenuItem { get; private set; } = null!;

        // Construtor privado para o EF Core
        private DailySpecial() { }

        // Construtor público de criação
        public DailySpecial(Guid restaurantId, Guid menuItemId, DateOnly date, string? highlightText = null)
        {
            if (restaurantId == Guid.Empty)
                throw new ArgumentException("RestaurantId não pode ser vazio.", nameof(restaurantId));

            if (menuItemId == Guid.Empty)
                throw new ArgumentException("MenuItemId não pode ser vazio.", nameof(menuItemId));

            if (date == default)
                throw new ArgumentException("A data do prato do dia é obrigatória.", nameof(date));

            RestaurantId = restaurantId;
            MenuItemId = menuItemId;
            Date = date;
            HighlightText = highlightText;
        }

        // Método de atualização do texto de destaque
        public void UpdateHighlight(string? newText)
        {
            HighlightText = newText;
        }
    }
}

