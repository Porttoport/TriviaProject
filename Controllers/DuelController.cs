using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TriviaProject.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace TriviaProject.Controllers
{
    public class DuelController : Controller
    {

        private TriviaContext _context;

        public DuelController(TriviaContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;

        }

        [HttpGet("/dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var model = await GetResults();

            return View("Dashboard", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //setup API call
        // referred to https://nimblegecko.com/how-to-call-json-api-and-display-result-in-asp-net-core-mvc/

        private readonly IHttpClientFactory _httpClientFactory;

        // public MyApiWrapper(IHttpClientFactory httpClientFactory)
        // {
        //     _httpClientFactory = httpClientFactory;
        // }

        // public Task PingResult()
        // {
        //     var client = _httpClientFactory.CreateClient("API Client");
        //     return client.GetStringAsync("/ping");
        // }
        // }

        private async Task<Root> GetResults()
        {
            // Get an instance of HttpClient from the factpry that we registered
            // in Startup.cs
            // HttpClient client = new()
            // {
            //     BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
            // };
            var client = _httpClientFactory.CreateClient("API Client");

            // Call the API & wait for response. 
            // If the API call fails, call it again according to the re-try policy
            // specified in Startup.cs
            var result = await client.GetAsync($"https://opentdb.com/api.php?amount=1&difficulty=medium&type=boolean");
            //alternate version with variables     var result = await client.GetAsync($"?amount={amount}&category={categoryId}&difficulty={difficulty}&type={answerType}");

            if (result.IsSuccessStatusCode)
            {
                // Read all of the response and deserialise it into an instace of
                // Result class
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Root>(content);
            }
            return null;
        }


        public async Task<IActionResult> Index()
        {
            var model = await GetResults();
            // Pass the data into the View
            return View("Dashboard", model);
        }

    }
}


// // Reference Newtonsoft
// using Newtonsoft.Json;

// // ... other code...

//     private async Task<Result> GetResults()
//     {
//         // Get an instance of HttpClient from the factpry that we registered
//         // in Startup.cs
//         var client = _httpClientFactory.CreateClient("API Client");

//         // Call the API & wait for response. 
//         // If the API call fails, call it again according to the re-try policy
//         // specified in Startup.cs
//         var result = await client.GetAsync($"?amount=10&category=12&difficulty=medium&type=boolean");
//    //alternate version with variables     var result = await client.GetAsync($"?amount={amount}&category={categoryId}&difficulty={difficulty}&type={answerType}");

//         if (result.IsSuccessStatusCode)
//         {
//             // Read all of the response and deserialise it into an instace of
//             // Result class
//             var content = await result.Content.ReadAsStringAsync();
//             return JsonConvert.DeserializeObject<Result>(content);
//         }
//         return null;
//     }

//     public async Task<IActionResult> Index()
//     {
//         var model = await GetResults();
//         // Pass the data into the View
//         return View(model);
//     }