using System;
using System.Collections.Generic;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
    public class BruleurDto
    {
        public Guid ComposantId { get; set; }
        public DateTime DateAcquisition { get; set; }
        public decimal PrixAcquisition { get; set; }
        public EtatComposant Etat { get; set; }
        public Guid ChaudiereId { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public TypeBruleur Type { get; set; }
        public int AnneeFabrication { get; set; }
        public decimal PuissanceElectrique { get; set; }
       // public ChaudiereDtoFilialeUnite Chaudiere { get; set; }
    }

    //public class ChaudiereDtoFilialeUnite
    //{
    //    public Guid ChaudiereId { get; set; }
    //    public int Numero { get; set; }
    //    public Guid UniteId { get; set; }
    //    public string Unite { get; set; }
    //    public Guid FilialeId { get; set; }
    //    public string Filiale { get; set; }
    //}

    public enum TypeBruleur
    {
        TOR,
        Modulant
    }
}
