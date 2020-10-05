using Chaufferie.ChargesMS.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Models
{
    public class ChAmortissement
    {
        public IEnumerable<ComposantDto> Composants { get; set; }
        public IEnumerable<AccessoiresDto> Accessoires { get; set; }
        public decimal SommeChargesMensuelle { get; set; }
    }
}
