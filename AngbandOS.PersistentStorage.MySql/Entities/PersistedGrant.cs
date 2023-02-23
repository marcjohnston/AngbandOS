namespace AngbandOS.PersistentStorage.MySql.Entities
{
    public partial class PersistedGrant
    {
        public string Key { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string? SubjectId { get; set; }
        public string? SessionId { get; set; }
        public string ClientId { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? Expiration { get; set; }
        public DateTime? ConsumedTime { get; set; }
        public string Data { get; set; } = null!;
    }
}
