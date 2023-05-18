namespace AngbandOS.Core.Genders
{
    internal abstract class Gender
    {
        protected readonly SaveGame SaveGame;
        protected Gender(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }
        public abstract string Title { get; }
        public abstract string Winner { get; }

        public virtual bool CanBeRandomlySelected => true;
        [Obsolete]
        public abstract int Index { get; }
    }
}
