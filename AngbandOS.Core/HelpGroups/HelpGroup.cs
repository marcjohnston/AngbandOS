namespace AngbandOS.Core.HelpGroups
{
    internal abstract class HelpGroup
    {
        protected SaveGame SaveGame { get; }
        protected HelpGroup(SaveGame saveGame) 
        {
            SaveGame = saveGame;
        } 
        public abstract string Title { get; }
        public abstract int SortIndex { get; }
    }
}
