using Chaufferie.ChargesMS.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chaufferie.ChargeMS.Data.Repository
{
    public class UserRepostiory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserRepostiory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IEnumerable<UserDto>> GetListUser(Guid FkSubsidiary)
        {
            var httpClient = _httpClientFactory.CreateClient("UserMsClient");
            var response = await httpClient.GetAsync($"User/GetAllActiveUserByFkSubsidiary?FkSubsidiary="+ FkSubsidiary);
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var UserList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserDto>>(responseStream);

                return await Task.FromResult(UserList);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<UserDto>> GetListUserByMatricule(List<string> ListMatricules)
        {
            UriBuilder baseUri = new UriBuilder("http://192.168.160.74:31633/production-user-management/api/user/GetUserByListMatricule");
            string queryToAppend = "ListMatricules=";
            foreach (string matricule in ListMatricules)
            {

                if (baseUri.Query != null && baseUri.Query.Length > 1)
                    baseUri.Query = baseUri.Query.Substring(1) + "&" + queryToAppend + matricule.ToString();
                else
                    baseUri.Query = queryToAppend + matricule.ToString();
            }

            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync(baseUri.ToString());
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var UserList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserDto>>(responseStream);

                return await Task.FromResult(UserList);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
