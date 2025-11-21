using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities
{
    public class Restaurant
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Timezone { get; private set; } = "America/Sao_Paulo";
        public bool IsActive { get; private set; } = true;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public ICollection<Category> Categories { get; private set; } = new List<Category>();
        public ICollection<MenuItem> MenuItems { get; private set; } = new List<MenuItem>();


        private Restaurant() { }//Intencao Ler Restaurante //Reflexão do EF permite acessar construtor privado
        public Restaurant(string name, string? timezone = null)//Intenção criar novo restaurante
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (!string.IsNullOrWhiteSpace(timezone)) Timezone = timezone!;

            //if (y != null)
            //    Name = name;
            //else
            //    Name = exception;

        }
        public void Rename(string rename)
        {
            if (string.IsNullOrWhiteSpace(rename)) throw new ArgumentNullException(nameof(rename));
            Name = rename;
        }

        public void Activate() => IsActive = true;

        public void Deactivate() => IsActive = false;

    }

}

