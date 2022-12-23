namespace AngbandOS.Core.EventArgs
{

    internal class ReadScrollEvent
    {
        /// <summary>
        /// Provided to the scroll for access to the entire game structure.  Future version may only limit what the scroll has access to.
        /// </summary>
        public SaveGame SaveGame { get; }

        /// <summary>
        /// Returns whether or not the scroll was identified after being read.  Returns false, by default.  Set to true, to identify the scroll to the player.
        /// </summary>
        public bool Identified { get; set; } = false;

        /// <summary>
        /// Returns whether or not the scroll is used up after being read.  Returns true, by default.  Set to false, to keep the scroll after being read.
        /// </summary>
        public bool UsedUp { get; set; } = true;

        public ReadScrollEvent(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }
    }
}
