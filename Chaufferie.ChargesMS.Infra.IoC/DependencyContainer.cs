using Chaufferie.ChargeMS.Data.Repository;
using Chaufferie.ChargesMS.Domain.Interfaces;
using Chaufferie.ChargesMS.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Chaufferie.ChargesMS.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {

            services.AddTransient<IGenericRepository<ChAssistExterne>, GenericRepository<ChAssistExterne>>();
            services.AddTransient<IGenericRepository<BureauControle>, GenericRepository<BureauControle>>();
            services.AddTransient<IGenericRepository<ChPieceRechange>, GenericRepository<ChPieceRechange>>();
            services.AddTransient<IGenericRepository<ChPersonnel>, GenericRepository<ChPersonnel>>();
           // services.AddTransient<IGenericRepository<TypeIntervention>, GenericRepository<TypeIntervention>>();
            services.AddTransient<IGenericRepository<Filiale>, GenericRepository<Filiale>>();
            services.AddTransient<IGenericRepository<Consommable>, GenericRepository<Consommable>>();
            services.AddTransient<IGenericRepository<TypeConsommable>, GenericRepository<TypeConsommable>>();
            services.AddTransient<IGenericRepository<ChEau>, GenericRepository<ChEau>>();
            services.AddTransient<IGenericRepository<ChElectrique>, GenericRepository<ChElectrique>>();
            services.AddTransient<IGenericRepository<ChCombustible>, GenericRepository<ChCombustible>>();
            services.AddTransient<UserRepostiory>();
            services.AddTransient<FicheSuiviRepository>();
            services.AddTransient<ChaudiereRepository>();

        }
    }
}
