namespace AngbandOS.Web.Models
{
    public class ChatMessage
    {
        public DateTime sentDateTime { get; set; }
        public string message { get; set; }
        public string fromUsername { get; set; }
    }
}
