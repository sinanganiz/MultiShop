using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Marka Listesi";
            ViewBag.v0 = "Marka İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Brands");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateBrand")]
        public IActionResult CreateBrand()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Yeni Marka";
            ViewBag.v0 = "Yeni Marka";

            return View();
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBrandDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7070/api/Brands", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }

            return View();
        }

        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7070/api/Brands?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }

            return View();
        }


        [Route("UpdateBrand/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Markalar";
            ViewBag.v3 = "Marka Güncelle";
            ViewBag.v0 = "Marka Güncelle";


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Brands/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [Route("UpdateBrand/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrand)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBrand);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/Brands/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }

            return View();
        }
    }
}
