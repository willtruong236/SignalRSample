using Microsoft.AspNetCore.SignalR;

namespace SignalRSample.Hubs
{
    public class SoccerTeamHub : Hub
    {
        public Dictionary<string, int> GetVoteResult()
        {
            return SD.MostFavouriteSoccerTeam;
        }
    }
}
