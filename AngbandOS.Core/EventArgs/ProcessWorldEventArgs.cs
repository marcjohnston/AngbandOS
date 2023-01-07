namespace AngbandOS.Core.EventArgs
{
    internal class ProcessWorldEventArgs
    {
        public bool DisableRegeneration = false;
        public SaveGame SaveGame { get; }
        public ProcessWorldEventArgs(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }
    }
}
