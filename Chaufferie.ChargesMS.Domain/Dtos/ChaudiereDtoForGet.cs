using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
    public class ChaudiereDtoForGet
    {
       
      
            public Guid ChaudiereId { get; set; }
            public string MarqueCorpsDeChauffe { get; set; }
            public ChaudiereType Type { get; set; }
            public string TypeChaudiere { get; set; }
            public Guid TypeChaudiereId { get; set; }
            public int Numero { get; set; }
            public string Unite { get; set; }
            public string Filiale { get; set; }
            public int DateFabrication { get; set; }
            public decimal? Capacite { get; set; }
            public decimal PressionService { get; set; }
            public TypeCombustible TypeCombustible { get; set; }
            public UniteCombustible? UniteCombustible { get; set; }
            public Guid subsidiaryId { get; set; }
            public TypeBacheAlimentaire TypeBacheAlimentaire { get; set; }
        
    }
    public enum TypeCombustible
    {
        Gaz,
        Fuel,
        Gasoil,
        AirChaud
    }

    public enum UniteCombustible
    {
        m3,
        tonne,
        litre
    }
}
