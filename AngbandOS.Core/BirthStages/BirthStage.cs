namespace AngbandOS.Core.BirthStages
{
    internal abstract class BaseBirthStage
    {
        protected readonly SaveGame SaveGame;
        protected BaseBirthStage(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }

        public abstract string[] GetMenu();
        public virtual void SelectionChanged() { }
    }
}
