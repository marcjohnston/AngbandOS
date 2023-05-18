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
        public virtual void RenderSelection(int index) { }

        /// <summary>
        /// Returns the next birth stage.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public abstract int? GoForward(int index);

        public abstract int? GoBack();
    }

    internal class ConfirmationBirthState : BaseBirthStage
    {
        private ConfirmationBirthState(SaveGame saveGame) : base(saveGame) { }

        public override string[]? GetMenu()
        {
            return null;
        }

        public override int? GoForward(int index)
        {
            return null;
        }

        public override int? GoBack()
        {
            return BirthStage.GenderSelection;
        }
    }
}
