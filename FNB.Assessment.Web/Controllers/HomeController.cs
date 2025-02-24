using FNB.Assessment.Services.Api.Entities;
using FNB.Assessment.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace FNB.Assessment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[LocalhostAuthorizeAttribute]  
        public IActionResult GetChange(ChangeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Amount <= 0)
                {
                    ViewBag.Error = "Amount must be greater than zero.";
                    return View("Index");
                }
                else if ((model.Amount * 100) % 5 != 0)
                {
                    ViewBag.Error = "Amount must be a multiple of 5 cents.";
                    return View("Index");
                }
                var splitCoinValues = model.Denominations.Split(',');
                int[] denominations = new int[splitCoinValues.Length];
                for (int i = 0; i < splitCoinValues.Length; i++)
                {
                    denominations[i] = int.Parse(splitCoinValues[i]);
                }

                var requestBody = new ChangeRequest() { Amount = model.Amount, Denominations = denominations };

                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile("appsettings.json");
                var configuration = configurationBuilder.Build();
                
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(configuration.GetValue<string>("Change_Api_Endpoint"));
                request.Method = "POST";
                request.ContentType = "application/json";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(requestBody));
                }
                WebResponse response = request.GetResponse();
                if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        ViewBag.Amount = model.Amount;
                        var lines = result.Split('\r');
                        ViewBag.Result = lines;
                        return View("Result");
                    }
                }
            }
            
            ViewBag.Error = "Change cannot be calculated with the available coins.";
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
