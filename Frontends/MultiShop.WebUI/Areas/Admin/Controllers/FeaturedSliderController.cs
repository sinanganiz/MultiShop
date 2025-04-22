using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeaturedSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeaturedSlider")]
    public class FeaturedSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeaturedSliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkanlar Listesi";
            ViewBag.v0 = "Öne Çıkanlar İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/FeaturedSliders");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeaturedSliderDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateFeaturedSlider")]
        public IActionResult CreateFeaturedSlider()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Önce Çıkanlar";
            ViewBag.v3 = "Yeni Öne Çıkan";
            ViewBag.v0 = "Yeni Öne Çıkan";

            return View();
        }

        [HttpPost]
        [Route("CreateFeaturedSlider")]
        public async Task<IActionResult> CreateFeaturedSlider(CreateFeaturedSliderDto createFeaturedSliderDto)
        {
            createFeaturedSliderDto.Status = false;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeaturedSliderDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7070/api/FeaturedSliders", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeaturedSlider", new { area = "Admin" });
            }

            return View();
        }

        [Route("DeleteFeaturedSlider/{id}")]
        public async Task<IActionResult> DeleteFeaturedSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7070/api/FeaturedSliders?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeaturedSlider", new { area = "Admin" });
            }

            return View();
        }


        [Route("UpdateFeaturedSlider/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeaturedSlider(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Önce Çıkanlar";
            ViewBag.v3 = "Öne Çıkan Güncelle";
            ViewBag.v0 = "Öne Çıkan Güncelle";


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/FeaturedSliders/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFeaturedSliderDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [Route("UpdateFeaturedSlider/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeaturedSlider(UpdateFeaturedSliderDto updateFeaturedSlider)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFeaturedSlider);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/FeaturedSliders/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeaturedSlider", new { area = "Admin" });
            }

            return View();
        }
    }
}
