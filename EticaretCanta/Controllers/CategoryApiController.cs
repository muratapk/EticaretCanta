using EticaretCanta.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EticaretCanta.Controllers
{
    public class CategoryApiController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7296/api/");
        private readonly HttpClient _client;

        public CategoryApiController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
           List<Categories> categories = new List<Categories>();    
            HttpResponseMessage response=_client.GetAsync(_client.BaseAddress+"Category/").Result;
            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                categories = JsonConvert.DeserializeObject<List<Categories>>(data);
            }

            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Categories categories)
        {
            try
            {
                string data = JsonConvert.SerializeObject(categories);
                StringContent content = new StringContent(data, Encoding.UTF8, "Application/Json");
                HttpResponseMessage message = _client.PostAsync(_client.BaseAddress + "Category", content).Result;
            }
            catch (Exception ex)
            {

                Response.WriteAsync(ex.Message);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Category/Delete" + id).Result;
                if(response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                Response.WriteAsync(ex.Message);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Categories categories = new Categories();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "Category/" + id).Result;
                if(response.IsSuccessStatusCode)
                {
                    string data=response.Content.ReadAsStringAsync().Result;
                    categories = JsonConvert.DeserializeObject<Categories>(data);
                    return View(categories);
                }
            }
            catch (Exception ex)
            {

                Response.WriteAsync("Hata Oluştu" + ex.Message);
                return View();
            }

            return View();
        }
        [HttpPost]
        public IActionResult Edit(int id, Categories categories)
        {
            try
            {
                string data = JsonConvert.SerializeObject(categories);
                StringContent content = new StringContent(data, Encoding.UTF8, "Application/Json");
                HttpResponseMessage message = _client.PutAsync(_client.BaseAddress + "Category", content).Result;
               if(message.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                Response.WriteAsync("Hata Oluştu" + ex.Message);
                return View();
            }
            return View();
        }
    }
}
