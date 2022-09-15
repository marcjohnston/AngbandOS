namespace AngbandOS.Web.Interface
{
    public class MessageDetails
    {
        public int Id { get; set; }
        public DateTime SentDateTime { get; set; }
        public string Message { get; set; }
        public string FromId { get; set; }
        public MessageTypeEnum Type { get; set; }
    }
}
