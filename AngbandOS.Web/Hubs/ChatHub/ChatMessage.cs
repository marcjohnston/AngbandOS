namespace AngbandOS.Web
{
    /// <summary>
    /// Represents a chat message that is sent from the GameService to a web client.
    /// </summary>
    public class ChatMessage
    {
        public int Id { get; set; }

        /// <summary>
        /// Returns the date and time the message was sent.  The time-zone is included.
        /// </summary>
        public DateTimeOffset SentDateTime { get; set; }
        public string Message { get; set; }
        public string FromUsername { get; set; }
    }
}
