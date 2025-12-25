using System;
using System.Collections.Generic;

namespace AngbandOS.PersistentStorage.MySql.Entities
{
    public partial class Savedgamecontent
    {
        public Savedgamecontent()
        {
            Savedgames = new HashSet<Savedgame>();
        }

        public int Id { get; set; }
        public byte[] Data { get; set; } = null!;

        public virtual ICollection<Savedgame> Savedgames { get; set; }
    }
}
