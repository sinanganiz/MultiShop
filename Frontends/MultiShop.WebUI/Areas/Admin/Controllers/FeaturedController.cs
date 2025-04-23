using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeaturedDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Featured")]
    public class FeaturedController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeaturedController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkanlar Listesi";
            ViewBag.v0 = "Öne Çıkan İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Featureds");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeaturedDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateFeatured")]
        public IActionResult CreateFeatured()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Yeni Öne Çıkan";
            ViewBag.v0 = "Yeni Öne Çıkan";

            return View();
        }

        [HttpPost]
        [Route("CreateFeatured")]
        public async Task<IActionResult> CreateFeatured(CreateFeaturedDto createFeaturedDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeaturedDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7070/api/Featureds", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Featured", new { area = "Admin" });
            }

            return View();
        }

        [Route("DeleteFeatured/{id}")]
        public async Task<IActionResult> DeleteFeatured(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7070/api/Featureds?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Featured", new { area = "Admin" });
            }

            return View();
        }


        [Route("UpdateFeatured/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeatured(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkan Güncelle";
            ViewBag.v0 = "Öne Çıkan Güncelle";


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Featureds/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFeaturedDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [Route("UpdateFeatured/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeatured(UpdateFeaturedDto updateFeatured)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFeatured);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/Featureds/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Featured", new { area = "Admin" });
            }

            return View();
        }
    }
}
