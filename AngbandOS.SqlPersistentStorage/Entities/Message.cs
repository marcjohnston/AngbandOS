using System;
using System.Collections.Generic;

namespace AngbandOS.PersistentStorage.Sql.Entities
{
    public partial class Message
    {
        public int Id { get; set; }
        public string FromUserId { get; set; } = null!;
        public string? ToUserId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime SentDateTime { get; set; }
        public int Type { get; set; }
        public string? GameId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual AspNetUser FromUser { get; set; } = null!;
        public virtual AspNetUser? ToUser { get; set; }
    }
}
