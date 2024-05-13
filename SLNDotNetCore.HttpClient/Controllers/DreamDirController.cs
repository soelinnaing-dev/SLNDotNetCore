using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SLNDotNetCore.HttpClient.Model;
using System.Text;

namespace SLNDotNetCore.HttpClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DreamDirController : ControllerBase
    {     
        private async Task<MainDto>GetData()
        {
            string jsonString = await System.IO.File.ReadAllTextAsync(".\\Model\\data.json");
            var model = JsonConvert.DeserializeObject<MainDto>(jsonString);
            return model!;           
        }

        [HttpGet]
        public async Task<IActionResult>ShowAlphabet()
        {
            var item =await GetData();
            var alphabetList = item.BlogHeader.Select(alphabet => alphabet.BlogHead).ToList();
            var alphabetTable = new StringBuilder();
            for (int i = 0; i < alphabetList.Count; i++)
            {
                alphabetTable.Append(alphabetList[i]);
                alphabetTable.Append((i + 1) % 5 == 0 ? Environment.NewLine : " ");
            }
            return Ok(alphabetTable.ToString());
        }

        [HttpGet("{alphabet}")]
        public async Task<IActionResult> SearchBlogContentByAlphabet(string alphabet)
        {
            var item = await GetData();

            var blogId = item.BlogHeader.Where(x => x.BlogHead == alphabet).Select(x =>
            {
                x.BlogHead = alphabet;
                return x.BlogId;
            }).FirstOrDefault();

            if (blogId is 0)
            {
                return NotFound("No result found!");
            }

            //var result = item.BlogDetail.Where(x => x.BlogId == blogId).ToList();     //Return All Detail
            var result = item.BlogDetail.Where(x => x.BlogId == blogId).Select(x => x.BlogContent).ToList(); //Return Only BlogContent
            return Ok(result);
        }
    }
}
