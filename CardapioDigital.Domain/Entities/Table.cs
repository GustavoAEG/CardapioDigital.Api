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
        public byte[]? TokenHash { get; private set; }
        public bool IsActive { get; private set; } = true;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? TokenExpiresAt { get; private set; }

        private Table() { }
        public Table(Guid restaurantId, string code, byte[]? tokenHash = null)
        {
            RestaurantId = restaurantId;
            if (string.IsNullOrWhiteSpace(code)) throw new ArgumentNullException(nameof(code));
            Code = code; TokenHash = tokenHash;
        }
        public void SetTokenHash(byte[] hash, DateTime expiresAt)
        {
            TokenHash = hash;
            TokenExpiresAt = expiresAt;
        }
        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
    }
}
