using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MMSDotNetCore.RestApiWithNLayer.Features.IncompatibleFood
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncompatibleFoodController : ControllerBase
    {
        private readonly IncompatibleFood _data;
        public IncompatibleFoodController()
        {

        }

        private async Task<IncompatibleFood> GetDataAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("IncompatibleFood.json");
            IncompatibleFood data = JsonConvert.DeserializeObject<IncompatibleFood>(jsonStr);
            return data;
        }

        [HttpGet("IncompatibleFood")]
        public async Task<IActionResult> GetIncompatibleFood()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_IncompatibleFood);
        }

        [HttpGet("Description")]
        public async Task<IActionResult> GetDescription()
        {
            var model = await GetDataAsync();
            var distinctDescriptions = model.Tbl_IncompatibleFood
                               .Select(x => x.Description)
                               .Distinct()
                               .ToList();
            return Ok(distinctDescriptions);
        }

        [HttpGet("{description}")]
        public async Task<IActionResult> GetDescription(string description)
        {
            var model = await GetDataAsync();
            var lst = model.Tbl_IncompatibleFood.Where(x => x.Description == description)
                               .ToList();
            return Ok(lst);
        }

        [HttpGet("{foodA}/foodB")]
        public async Task<IActionResult> GetDescription(string foodA, string foodB)
        {
            var model = await GetDataAsync();
            var data = model.Tbl_IncompatibleFood.FirstOrDefault(x => x.FoodA == foodA && x.FoodB == foodB);
            return Ok(data.Description);
        }
    }

    public class IncompatibleFood
    {
        public Tbl_Incompatiblefood[] Tbl_IncompatibleFood { get; set; }
    }

    public class Tbl_Incompatiblefood
    {
        public int Id { get; set; }
        public string FoodA { get; set; }
        public string FoodB { get; set; }
        public string Description { get; set; }
    }
}
