namespace AngbandOS.Core.BirthStages
{
    [Serializable]
    internal class NamingBirthStage : BaseBirthStage
    {
        private NamingBirthStage(SaveGame saveGame) : base(saveGame) { }
        public override string[]? GetMenu()
        {
            return null;
        }
        public override bool RenderSelection(int index)
        {
            SaveGame.Player.InputPlayerName();
            return false;
        }

        public override int? GoForward(int index)
        {
            return null;
        }

        public override int? GoBack()
        {
            return BirthStage.Confirmation;
        }
    }
}
