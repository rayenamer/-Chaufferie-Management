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
    }
}
