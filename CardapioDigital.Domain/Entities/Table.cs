using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities
{
    public class Table
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid RestaurantId { get; private set; }
        public string Code { get; private set; }

        private Table() { }
        public Table(Guid restaurantId, string code)
        {
            RestaurantId = restaurantId;
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }
    }
}
