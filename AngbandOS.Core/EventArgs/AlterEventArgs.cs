namespace AngbandOS.Core.EventArgs
{
    internal class AlterEventArgs
    {
        public SaveGame SaveGame { get; }
        public bool Disturbed = false;

        public int X { get; }
        public int Y { get; }

        public AlterEventArgs(SaveGame saveGame, int y, int x)
        {
            SaveGame = saveGame;
            X = x;
            Y = y;
        }
    }
}
