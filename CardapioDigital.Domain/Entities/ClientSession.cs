using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities
{
    public class ClientSession
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid RestaurantId { get; private set; }
        public Guid TableId { get; private set; }
        public byte[] SessionTokenHash { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        private ClientSession() { }
        public ClientSession(Guid restaurantId, Guid tableId, byte[] sessionTokenHash, DateTime expiresAt)
        {
            RestaurantId = restaurantId;
            TableId = tableId;
            SessionTokenHash = sessionTokenHash ?? throw new ArgumentNullException(nameof(sessionTokenHash));
            ExpiresAt = expiresAt;
        }
    }
}
