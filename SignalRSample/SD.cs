namespace SignalRSample
{
    public static class SD
    {
        static SD()
        {
            MostFavouriteSoccerTeam = new Dictionary<string, int>();
            MostFavouriteSoccerTeam.Add("mu", 0);
            MostFavouriteSoccerTeam.Add("rm", 0);
            MostFavouriteSoccerTeam.Add("psg", 0);
        }

        public static Dictionary<string, int> MostFavouriteSoccerTeam;
    }
}
