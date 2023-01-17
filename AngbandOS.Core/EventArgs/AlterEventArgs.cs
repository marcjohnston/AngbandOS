namespace AngbandOS.Core.EventArgs
{
    internal class AlterEventArgs
    {
        public SaveGame SaveGame { get; }

        /// <summary>
        /// Return true, if the command can be continued; false, if the command succeeded or is futile and should not be repeated.
        /// </summary>
        public bool More = false;

        /// <summary>
        /// Returns the x-coordinate of the player.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Returns the y-coordinate of the player.
        /// </summary>
        public int Y { get; }

        public AlterEventArgs(SaveGame saveGame, int y, int x)
        {
            SaveGame = saveGame;
            X = x;
            Y = y;
        }
    }
}
