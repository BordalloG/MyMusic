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
        private readonly string spotifyToken = "BQA2JW6xHqM-MhW8YCHFzGcQKwgLKYOLBbzheYrSrdI5gt6NZ6C4b-0WzaQ8TTnoXhiIYovsmN9WSsN3jnBJpTW_c3pYuA3pa751WRZSo6ykScr4sMaDXhkA0vWO9LAXNT1_ggLM";
        public async Task<string> HttpGet(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spotifyToken);
            HttpResponseMessage response = await client.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
