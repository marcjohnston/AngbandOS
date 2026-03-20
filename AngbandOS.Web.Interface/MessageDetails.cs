namespace AngbandOS.Web.Interface
{
    /// <summary>
    /// Represents a persisted message.
    /// </summary>
    public class MessageDetails
    {
        public int Id { get; set; }

        /// <summary>
        /// Returns the date and time the message was sent.  The time-zone is not persisted.
        /// </summary>
        public DateTime SentDateTime { get; set; }
        public string Message { get; set; }
        public string FromId { get; set; }
        public string ToId { get; set; }

        public MessageTypeEnum Type { get; set; }
    }
}
