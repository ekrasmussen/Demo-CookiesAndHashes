using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace CookiesAndHashes.Services
{
    internal abstract class Connection
    {
        const string baseurl = "localhost:7069/api/";

        readonly HttpClient client;
        readonly JsonSerializer serializer;

        protected Connection()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://" + baseurl);

            serializer = new JsonSerializer();
        }

        protected async Task<GetResult> GetFromAPI<GetResult>(string path)
        {
            var response = await client.GetAsync(path, HttpCompletionOption.ResponseHeadersRead);

            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var sr = new StreamReader(stream))
                using (var textReader = new JsonTextReader(sr))
                {
                    return serializer.Deserialize<GetResult>(textReader)!;
                }
            }

            return default!;
        }
    }
}
