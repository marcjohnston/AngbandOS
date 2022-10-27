namespace AngbandOS.Web.Models
{
    public class HubConnections
    {
        public ActiveUserDetails[] ChatHubConnections { get; set; }
        public ActiveUserDetails[] AdminHubConnections { get; set; }
        public ActiveUserDetails[] GameHubConnections { get; set; }
        public ActiveUserDetails[] SpectatorsHubConnections { get; set; }
        public ActiveUserDetails[] ServiceHubConnections { get; set; }
    }
}
