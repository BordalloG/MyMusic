using MyMusic.Domain.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Domain.Implementations
{
    public class HttpClientHelperDomainService : IHttpClientHelperDomainService
    {
        private readonly string spotifyToken = "BQACthOrEoIipUDkfaaDp9XAJfQjErMsWFnyx8TaFnq9pc5SCESba-JldE_8TF84Cdap2TcDcvWJVtJxtDl8nivWuG10d6DE9sGX6m6Wr3lQwy2a8y3D4B5vM7Du21JTA_EpUERc";
        public async Task<string> HttpGet(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spotifyToken);
            HttpResponseMessage response = await client.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
