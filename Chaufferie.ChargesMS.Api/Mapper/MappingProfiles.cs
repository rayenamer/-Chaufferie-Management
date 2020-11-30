using AutoMapper;
using Chaufferie.ChargesMS.Domain.Dtos;
using Chaufferie.ChargesMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaufferie.ChargesMS.Api.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Map Charges AssistExterne
            CreateMap<ChAssistExterne, ChAssistExterneDtoForRead>()
                        //.ForMember(m => m.LibelleTypeIntervention, i => i.MapFrom(src => src.TypeIntervention.Libelle))
                        .ForMember(m => m.LibelleBureauControle, i => i.MapFrom(src => src.BureauControle.Libelle))
                        .ForMember(m => m.SubsidiaryLabel, i => i.MapFrom(src => src.Filiale.label))
                        .ReverseMap();
            #endregion

            #region Map Charges Personnel
            CreateMap<ChPersonnel, ChPersonnelDtoForRead>()
                            .ForMember(m => m.SubsidiaryLabel, i => i.MapFrom(src => src.Filiale.label))
                            .ReverseMap();
            #endregion

            #region Map Charges PieceRechange
            CreateMap<ChPieceRechange, ChPieceRechangeDtoForRead>()
                            .ForMember(m => m.SubsidiaryLabel, i => i.MapFrom(src => src.Filiale.label))
                            .ReverseMap();
            #endregion

            #region Map Charges Consommable
            CreateMap<Consommable, ConsommableDto>()
                        .ForMember(m => m.TypeConsommable, i => i.MapFrom(src => src.TypeConsommable.Libelle))
                        .ForMember(m => m.Filiale, i => i.MapFrom(src => src.Filiale.label))
                        .ReverseMap();
            #endregion

            #region Map Charges Consommations d'eau
            CreateMap<ChEau, ChEauDto>()
                        .ForMember(m => m.Filiale, i => i.MapFrom(src => src.Filiale.label))
                        .ReverseMap();
            #endregion

            #region Map Charges Consommations d'électricité
            CreateMap<ChElectrique, ChElectriqueDto>()
                        .ForMember(m => m.Filiale, i => i.MapFrom(src => src.Filiale.label))
                        .ReverseMap();
            #endregion

            #region Map Charges Consommations de combustible
            CreateMap<ChCombustible, ChCombustibleDto>()
                        .ForMember(m => m.Filiale, i => i.MapFrom(src => src.Filiale.label))
                        .ReverseMap();
            #endregion
        }
    }
    
}


