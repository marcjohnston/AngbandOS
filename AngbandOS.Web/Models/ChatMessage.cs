namespace AngbandOS.Web.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public DateTime SentDateTime { get; set; }
        public string Message { get; set; }
        public string FromUsername { get; set; }
    }
}
