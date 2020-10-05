using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Models
{
    public class BureauControle
    {
        [Key]
        public Guid BureauControleId { get; set; }
        public string Libelle { get; set; }
        public virtual ICollection<ChAssistExterne> ChAssistExeternes { get; set; }
    }
}
