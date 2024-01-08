using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRSample.Hubs;
using SignalRSample.Models;

namespace SignalRSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<SoccerTeamHub> _soccerHub;

        public HomeController(ILogger<HomeController> logger, IHubContext<SoccerTeamHub> soccerHub)
        {
            _logger = logger;
            _soccerHub = soccerHub;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SoccerTeams(string team)
        {
            if (SD.MostFavouriteSoccerTeam.ContainsKey(team))
            {
                SD.MostFavouriteSoccerTeam[team]++;
            }

            await _soccerHub.Clients.All.SendAsync("updateVote",
                SD.MostFavouriteSoccerTeam["mu"],
                SD.MostFavouriteSoccerTeam["rm"],
                SD.MostFavouriteSoccerTeam["psg"]);

            return Accepted();
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
