using CardapioDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Interfaces
{
    public interface IPaymentTokenRepository
    {
        Task AddAsync(PaymentToken token, CancellationToken ct = default);
    }

}
