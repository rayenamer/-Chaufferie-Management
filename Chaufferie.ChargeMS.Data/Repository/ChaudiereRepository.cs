using Chaufferie.ChargesMS.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chaufferie.ChargeMS.Data.Repository
{
    public class ChaudiereRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ChaudiereRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<AdoucisseurDto> GetAdoucisseur(Guid filialeId)
        {
            var httpClient = _httpClientFactory.CreateClient("ChaudiereMsClient");
            var response = await httpClient.GetAsync($"Adoucisseur/GetAdoucisseurByFilialeId?filialeId="+filialeId);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var Adoucisseur = Newtonsoft.Json.JsonConvert.DeserializeObject<AdoucisseurDto>(responseStream);

                return await Task.FromResult(Adoucisseur);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<AdoucisseurDto>> GetAdoucisseurList(Guid filialeId)
        {
            var httpClient = _httpClientFactory.CreateClient("ChaudiereMsClient");
            var response = await httpClient.GetAsync($"Adoucisseur/GetAdoucisseurListByFilialeId?filialeId=" + filialeId);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var Adoucisseur = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<AdoucisseurDto>>(responseStream);

                return await Task.FromResult(Adoucisseur);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        
        public async Task<IEnumerable<ChaudiereDtoForGet>> GetChaudiereDtoForGet(Guid filialeId)
        {
            var httpClient = _httpClientFactory.CreateClient("ChaudiereMsClient");
            var response = await httpClient.GetAsync($"Chaudiere/GetChaudiereDtoByFilialeId?filialeId=" + filialeId);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var Chaudiere = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ChaudiereDtoForGet>>(responseStream);

                return await Task.FromResult(Chaudiere);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public async Task<IEnumerable<BruleurDto>> GetBruleurByChaudiereId(Guid chaudiereId)
        {
            var httpClient = _httpClientFactory.CreateClient("ChaudiereMsClient");
            var response = await httpClient.GetAsync($"Bruleur/GetBruleurByChaudiereId?chaudiereId=" + chaudiereId);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var Bruleurs = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<BruleurDto>>(responseStream);

                return await Task.FromResult(Bruleurs);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<PompeAlimentaire>> GetPompeAlimentaireByChaudiereId(Guid chaudiereId)
        {
            var httpClient = _httpClientFactory.CreateClient("ChaudiereMsClient");
            var response = await httpClient.GetAsync($"PompeAlimentaire/GetPompeAlimentaireByChaudiereId?chaudiereId=" + chaudiereId);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var PompeAlimentaires = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<PompeAlimentaire>>(responseStream);

                return await Task.FromResult(PompeAlimentaires);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ComposantDto>> GetComposantsDto(Guid filialeId, string date)
        {
            var d = DateTime.Now;
            var httpClient = _httpClientFactory.CreateClient("ChaudiereMsClient");
            var response = await httpClient.GetAsync($"Composant/GetComposantDtoForCharges?subsidiaryId=" + filialeId+ "&date="+date);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var Composants = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<ComposantDto>>(responseStream);

                return await Task.FromResult(Composants);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<AccessoiresDto>> GetAccessoiresDto(Guid filialeId, string date)
        {
            var httpClient = _httpClientFactory.CreateClient("ChaudiereMsClient");
            var response = await httpClient.GetAsync($"Accessoires/GetAccessoiresDtoForCharges?subsidiaryId=" + filialeId + "&date=" + date);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var Composants = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<AccessoiresDto>>(responseStream);

                return await Task.FromResult(Composants);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<PrixEauOsmose> GetPrixOsmose(string month, string year)
        {
            var httpClient = _httpClientFactory.CreateClient("srvdevweb");
            var response = await httpClient.GetAsync($"helper/getIt?year=" + year + "&month=" + month);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var Composants = Newtonsoft.Json.JsonConvert.DeserializeObject<PrixEauOsmose>(responseStream);

                return await Task.FromResult(Composants);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public async Task<string> GetTypeChaudiereByFilialeId(Guid filialeId)
        {
            var httpClient = _httpClientFactory.CreateClient("ChaudiereMsClient");
            var response = await httpClient.GetAsync($"Chaudiere/GetTypeChaudiereByFilialeId?filialeId=" + filialeId);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var Type = responseStream;

                return await Task.FromResult(Type);
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}



