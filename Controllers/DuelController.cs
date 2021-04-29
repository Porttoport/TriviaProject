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
using Microsoft.EntityFrameworkCore;

namespace TriviaProject.Controllers
{
    public class DuelController : Controller
    {
        private int? uid
        {
            get
            {
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                // HttpContext.Session.SetInt32("UserId", 1); ////////////////////////////////////////////////////////////////////delete this 4 exam!
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                return HttpContext.Session.GetInt32("UserId");
            }
        }

        private bool isLoggedIn
        {
            get
            {
                return uid != null;
            }
        }

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

        [HttpGet("/duel/{duelId}")]
        public async Task<IActionResult> Duel(int duelId)
        {
            var model = await GetResults();
            ViewBag.question = model;

            return View("Duel", duelId);
        }


        [HttpGet("/leaderboard")]
        public IActionResult Leaderboard()
        {
            List<User> Leaderboard = _context.Users.Include(user => user.User1Duels).OrderByDescending(p => p.Score).ToList();
            ViewBag.Leaderboard = Leaderboard;

            User LoggedInUser = _context.Users.Include(u => u.User1Duels).ThenInclude(duel => duel.User2).FirstOrDefault(u => u.UserId == uid);
            return View("_Leaderboard");
        }


        [HttpGet("/user/detail/{userId}")]
        public IActionResult UserDetail(int userId)
        {
            List<User> Leaderboard = _context.Users
            .Include(user => user.User1Duels)
            .ThenInclude(duel => duel.User2)
            .OrderByDescending(p => p.Score).ToList();

            int count = 0;
            foreach (User leader in Leaderboard)
            {
                count++;
                if (leader.UserId == userId)
                {
                    break;
                }
            }
            ViewBag.Position = count;
            ViewBag.Leaderboard = Leaderboard;

            User LoggedInUser = _context.Users
            .Include(u => u.User1Duels)
            .ThenInclude(duel => duel.User2)
            .FirstOrDefault(u => u.UserId == uid);

            return View(Leaderboard);
        }

        [HttpGet("/challengeDuel/{userId}")]
        public IActionResult ChallengeDuel(int userId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("LoginRegPage", "Home");
            }

            Duel existingDuel = _context.Duels.FirstOrDefault(duel => duel.User1Id == (int)uid && duel.User2Id == userId || duel.User1Id == userId && duel.User2Id == (int)uid)

            if (!existingDuel)
            {
                Duel newDuel = new Duel()
                {
                    User1Id = (int)uid,
                    User2Id = userId,
                };
                _context.Duels.Add(newDuel);
                _context.SaveChanges();
            }


            User LoggedInUser = _context.Users.Include(u => u.User1Duels).ThenInclude(duel => duel.User2).FirstOrDefault(u => u.UserId == uid);


            return RedirectToAction("Duel", "Duel");
        }

        [HttpGet("/ForfeitDuel/{userId}")]
        public IActionResult ForfeitDuel(int userId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("LoginRegPage", "Home");
            }

            Duel existingDuel = _context.Duels.FirstOrDefault(duel => duel.User1Id == (int)uid);
            User Challenger = _context.Users.Include(u => u.User1Duels).ThenInclude(duel => duel.User2).FirstOrDefault(u => u.UserId == userId);
            User LoggedInUser = _context.Users.Include(u => u.User1Duels).ThenInclude(duel => duel.User2).FirstOrDefault(u => u.UserId == uid);

            if (existingDuel != null)
            {
                //add functionality to add points to challenger score
                Challenger.Score += 100;
                LoggedInUser.Score -= 100;

                //delete duel relationship
                _context.Duels.Remove(existingDuel);
                _context.SaveChanges();

            }

            return RedirectToAction("Leaderboard", "Duel");
        }



        // ================================================================================================================================
        //                                              API call handling   =================================================================================================================================
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
            return View("Dashboard", model);
        }

    }
}

