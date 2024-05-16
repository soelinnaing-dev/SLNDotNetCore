using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SLNDotNetCore.NLayer.Features.MyanmarProverbs
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProverbsController : ControllerBase
    {
        private async Task<DB_MyanmarProverb> GetData()
        {
            var jsonString = await System.IO.File.ReadAllTextAsync("MyanmarProverbs.json");
            var lst = JsonConvert.DeserializeObject<DB_MyanmarProverb>(jsonString);
            return lst;
        }

        [HttpGet]
        public async Task<IActionResult> ShowAllTitle()
        {
            var model = await GetData();
            var items = model.Tbl_MMProverbsTitle.Select(x => x.TitleName).ToList();
            var tableRows = new List<string>();
            for (int i = 0; i < items.Count; i += 5)
            {
                var row = string.Join(",", items.Skip(i).Take(5));
                tableRows.Add(row);
            }
            return Ok(tableRows);
        }

        [HttpGet("title/{titleName}")]
        public async Task<IActionResult> GetTitleByName(string titleName)
        {
            var model = await GetData();
            var titleId = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName)?.TitleId;
            var titles = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId).Select(x => x.ProverbName).ToList();
            return Ok(titles);
        }

        [HttpGet("proverb/{proveName}")]
        public async Task<IActionResult>GetProverbDesb(string proveName)
        {
            var model = await GetData();
            var proveDesb = model.Tbl_MMProverbs.Where(x=>x.ProverbName == proveName).Select(x => x.ProverbDesp);
            return Ok(proveDesb);
        }
    }
}
