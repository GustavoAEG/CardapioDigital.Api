using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public class Role
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }  // Admin, Garcom, Cozinha ...

    private Role() { }
    public Role(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        Name = name;
    }
}

