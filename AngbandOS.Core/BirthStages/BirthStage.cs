namespace AngbandOS.Core.BirthStages
{
    [Serializable]
    internal abstract class BaseBirthStage
    {
        protected readonly SaveGame SaveGame;
        protected BaseBirthStage(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }

        public abstract string[]? GetMenu();
        public abstract bool RenderSelection(int index);

        /// <summary>
        /// Returns the next birth stage.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public abstract int? GoForward(int index);

        public abstract int? GoBack();
    }
}
