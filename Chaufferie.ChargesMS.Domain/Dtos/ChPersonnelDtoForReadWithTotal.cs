using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
    public class ChPersonnelDtoForReadWithTotal
    {
        public List<ChPersonnelDtoForRead> ListChPersonnel { get; set; }
        public decimal TotalCharges { get; set; }
    }
}
