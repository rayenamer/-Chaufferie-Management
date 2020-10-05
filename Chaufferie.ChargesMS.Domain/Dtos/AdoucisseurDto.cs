using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chaufferie.ChargesMS.Domain.Dtos
{
    public class AdoucisseurDto
    {
        public Guid ComposantId { get; set; }
        public DateTime DateAcquisition { get; set; }
        public decimal PrixAcquisition { get; set; }
        public EtatComposant Etat { get; set; }
        public Guid ChaudiereId { get; set; }
        public decimal VolumeResine { get; set; }
        public decimal DebitUtilisation { get; set; }
        public string Type { get; set; }
    }


    public enum EtatComposant
    {
        Marche,
        ArretProduction
    }
}

