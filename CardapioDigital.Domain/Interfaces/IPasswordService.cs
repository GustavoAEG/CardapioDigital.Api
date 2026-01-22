using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Interfaces
{
    public interface IPasswordService
    {
        string Hash(string password);
        bool verify(string password, string hash);

    }
}
