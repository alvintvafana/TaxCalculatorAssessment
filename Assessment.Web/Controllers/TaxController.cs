using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Assessment.Web.Models;
using Microsoft.Extensions.Options;

namespace Assessment.Web.Controllers
{
    [Authorize]
    public class TaxController : Controller
    {
        private string _baseUrl;
        private readonly IHttpClientFactory _clientFactory;
        public  TaxController(IHttpClientFactory clientFactory,IOptions<Settings>options)
        {
            _clientFactory = clientFactory;
            _baseUrl = options.Value.BaseUrl;
        }
        public async Task<IActionResult> Index()
        {
            List<CalculatedTaxViewModel> calculatedTaxView = new List<CalculatedTaxViewModel>();
            HttpResponseMessage response = await HttpClientHelper().GetAsync($"{_baseUrl}tax/GetAllCalculatedTaxQuery");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                calculatedTaxView =
                    JsonConvert.DeserializeObject<List<CalculatedTaxViewModel>>(result);
            }
            return View(calculatedTaxView);
        }
       

        public async Task<IActionResult> ViewCalculatedTax(string calculatedTaxId)
        {
            HttpResponseMessage response = await HttpClientHelper().GetAsync($"{_baseUrl}tax/GetCalculatedTaxQuery?id={calculatedTaxId}");
            CalculatedTaxViewModel calculatedTaxView = new CalculatedTaxViewModel();
            if (response.IsSuccessStatusCode)
            {
                calculatedTaxView = await response.Content.ReadAsAsync<CalculatedTaxViewModel>();
            }
            return View(calculatedTaxView);
        }

        public IActionResult CalculateTax()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalculateTax(CalculateTaxViewModel calculateTax)
        {
            HttpResponseMessage response = await HttpClientHelper().PostAsJsonAsync( $"{_baseUrl}tax/CalculateTaxCommand", calculateTax);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var calculatedTaxID = await response.Content.ReadAsAsync<Guid>();
                return RedirectToAction("ViewCalculatedTax",new { calculatedTaxId = calculatedTaxID });
            }
            return View();
        }
        private HttpClient HttpClientHelper()
        {
            var client = _clientFactory.CreateClient();
            var token = HttpContext.GetTokenAsync("access_token").Result;
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            return client;
        }
    }
}
