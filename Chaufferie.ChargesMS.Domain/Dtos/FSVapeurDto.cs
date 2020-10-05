using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
    public class FSVapeurDto
    {
        public Guid FicheSuiviId { get; set; }
        public DateTime DateSaisie { get; set; }
        public int? ProductionUsine { get; set; }
        public Guid FKChaudiere { get; set; }
        public string MarqueCorpsDeChauffe { get; set; }
        public string Commentaire { get; set; }
        public int? IndexCombustible { get; set; }
        public int? IndexElectricite { get; set; }
        public string UniteCombustible { get; set; }
        public int? IndexEauAdoucie { get; set; }
        public int? IndexVapeur { get; set; }
        public decimal? TemperatureFumee { get; set; }
        public decimal? TemperatureBacheAlimentaire { get; set; }
        public decimal? TH_Eau_Chaudiere { get; set; }
        public decimal? PH_Eau_Chaudiere { get; set; }
        public decimal? Conductivite_Eau_Chaudiere { get; set; }
        public decimal? THe_Eau_Adoucie { get; set; }
        public decimal? THs_Eau_Adoucie { get; set; }
        public decimal? Conductivite_Eau_Adoucie { get; set; }
        public decimal? PH_Eau_Adoucie { get; set; }
        public decimal? PH_Eau_BacheAlimentaire { get; set; }
        public decimal? TH_Eau_BacheAlimentaire { get; set; }
        public decimal? Conductivite_Eau_BacheAlimentaire { get; set; }
        public decimal? Ph_RetourCondensat { get; set; }
        public decimal? Conductivite_RetourCondensat { get; set; }
        public string Unite { get; set; }
        public string Filiale { get; set; }
        public TypeBacheAlimentaire Type { get; set; }
        public int numero { get; set; }
        //public TypeCombustibleEnum TypeCombustible { get; set; }
        public bool Arret { get; set; }
        public Guid FkSubsidiary { get; set; }
        public ChaudiereType Type_Prin_Sec { get; set; }
        public decimal? Capacite { get; set; }

    }
    public enum TypeBacheAlimentaire
    {
        Degazant,
        Atmospherique
    }
    public enum ChaudiereType
    {
        Principale,
        Secours
    }


}
