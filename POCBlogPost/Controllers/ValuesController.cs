using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace POCBlogPost.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "POC Initiated" };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            //get repository
            var getRepo = Repo.RepositoryAsync(value).Result;
            
            //ignore blog posts with an even id
            var repository = getRepo.GroupBy(s => s.id).Select(s => s.First());

            //Serialize the result into a file with the following name: userid_yyyyMMdd_hhmmss.txt
            string FILE_NAME = Rules.GetFileName(value);

            using (StreamWriter sw = new StreamWriter(FILE_NAME))
            {
                foreach (var repo in repository)
                {
                    //The title shoud have only the last word
                    string title = repo.title;
                    repo.title = Rules.EditTitle(title);

                    //The body should have the first 15 chars and the last word
                    string body = repo.body;
                    repo.body = Rules.EditBody(body);

                    //writing the txt file.
                    sw.WriteLine($"userId: {repo.userId}");
                    sw.WriteLine($"id: {repo.id}");
                    sw.WriteLine($"title: {repo.title}");
                    sw.WriteLine($"body: {repo.body}");
                    sw.WriteLine(" ");
                }
            }
        }
    }
}
