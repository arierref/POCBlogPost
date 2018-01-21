using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Net.Http.Headers;

namespace POCBlogPost
{
    public class Repo
    {
        public static async Task<List<ListPost>> RepositoryAsync(string value)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var serializer = new DataContractJsonSerializer(typeof(List<ListPost>));

            var streamTask = client.GetStreamAsync($"https://jsonplaceholder.typicode.com/posts?userId={value}");
            var repositoryList = serializer.ReadObject(await streamTask) as List<ListPost>;

            return repositoryList;
        }
    }
}
