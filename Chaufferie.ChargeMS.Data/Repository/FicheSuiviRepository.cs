using Chaufferie.ChargesMS.Domain.Dtos;
using Chaufferie.ChargesMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chaufferie.ChargeMS.Data.Repository
{
    public class FicheSuiviRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FicheSuiviRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IEnumerable<FSVapeurDto>> GetListFSVapeur(Guid FkSusbsidiary)
        {
            var httpClient = _httpClientFactory.CreateClient("FicheSuiviMsClient");
            var response = await httpClient.GetAsync($"fsvapeur/GetListFsVapeurByFkSubsidiary?FkSusbsidiary=" + FkSusbsidiary);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var FSVapeurList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FSVapeurDto>>(responseStream);

                return await Task.FromResult(FSVapeurList);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public async Task<int?> GetSumConsommationGaz(Guid FkSusbsidiary, string date)
        {
            var httpClient = _httpClientFactory.CreateClient("FicheSuiviMsClient");
            var response = await httpClient.GetAsync($"FSVapeur/GetSumConsommationGaz?FkSubsidiary=" + FkSusbsidiary + "&date=" + date);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var Consommation = Newtonsoft.Json.JsonConvert.DeserializeObject<int?>(responseStream);

                return await Task.FromResult(Consommation);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<int?> GetSumConsommationElectricite(Guid FkSusbsidiary, string date)
        {
            var httpClient = _httpClientFactory.CreateClient("FicheSuiviMsClient");
            var response = await httpClient.GetAsync($"FSVapeur/GetSumConsommationElectricite?FkSubsidiary=" + FkSusbsidiary + "&date=" + date);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var Consommation = Newtonsoft.Json.JsonConvert.DeserializeObject<int?>(responseStream);

                return await Task.FromResult(Consommation);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public async Task<int?> GetSumConsommationEau(Guid FkSusbsidiary, string date)
        {
            var httpClient = _httpClientFactory.CreateClient("FicheSuiviMsClient");
            var response = await httpClient.GetAsync($"FSVapeur/GetSumConsommationEau?FkSubsidiary=" + FkSusbsidiary + "&date=" + date);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var Consommation = Newtonsoft.Json.JsonConvert.DeserializeObject<int?>(responseStream);

                return await Task.FromResult(Consommation);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<int?> GetSumConsommationVapeur(Guid FkSusbsidiary, string date)
        {
            var httpClient = _httpClientFactory.CreateClient("FicheSuiviMsClient");
            var response = await httpClient.GetAsync($"FSVapeur/GetSumConsommationVapeur?FkSubsidiary=" + FkSusbsidiary + "&date=" + date);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var Consommation = Newtonsoft.Json.JsonConvert.DeserializeObject<int?>(responseStream);

                return await Task.FromResult(Consommation);
            }
            catch (Exception e)
            {
                return null;
            }
        }




        public async Task<int?> GetSumConsommationEauRecuperation(Guid FkSusbsidiary, string date)
        {
            var httpClient = _httpClientFactory.CreateClient("FicheSuiviMsClient");
            var response = await httpClient.GetAsync($"FSRecuperation/GetSumConsommationEau?FkSubsidiary=" + FkSusbsidiary + "&date=" + date);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var Consommation = Newtonsoft.Json.JsonConvert.DeserializeObject<int?>(responseStream);

                return await Task.FromResult(Consommation);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public async Task<int?> GetSumConsommationGazRecuperation(Guid FkSusbsidiary, string date)
        {
            var httpClient = _httpClientFactory.CreateClient("FicheSuiviMsClient");
            var response = await httpClient.GetAsync($"FSRecuperation/GetSumConsommationGaz?FkSubsidiary=" + FkSusbsidiary + "&date=" + date);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var Consommation = Newtonsoft.Json.JsonConvert.DeserializeObject<int?>(responseStream);

                return await Task.FromResult(Consommation);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public async Task<int?> GetSumConsommationVapeurRecuperation(Guid FkSusbsidiary, string date)
        {
            var httpClient = _httpClientFactory.CreateClient("FicheSuiviMsClient");
            var response = await httpClient.GetAsync($"FSRecuperation/GetSumConsommationVapeur?FkSubsidiary=" + FkSusbsidiary + "&date=" + date);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var Consommation = Newtonsoft.Json.JsonConvert.DeserializeObject<int?>(responseStream);

                return await Task.FromResult(Consommation);
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}


