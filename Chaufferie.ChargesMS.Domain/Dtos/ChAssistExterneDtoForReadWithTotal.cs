using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
    public class ChAssistExterneDtoForReadWithTotal
    {
        public List<ChAssistExterneDtoForRead> ListChAssistExterne { get; set; }
        public decimal TotalCharges { get; set; }
    }
}
