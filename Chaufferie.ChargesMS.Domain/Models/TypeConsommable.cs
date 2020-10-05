using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Models
{
    public class TypeConsommable
    {
        [Key]
        public Guid TypeConsommableId { get; set; }
        public string Libelle { get; set; }

        public virtual ICollection<Consommable> Consommables { get; set; }
    }
}
