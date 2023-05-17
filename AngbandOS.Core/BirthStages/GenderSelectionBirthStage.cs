namespace AngbandOS.Core.BirthStages
{
    internal class GenderSelectionBirthStage : BaseBirthStage
    {
        private GenderSelectionBirthStage(SaveGame saveGame) : base(saveGame) { }
        public override string[] GetMenu()
        {
            return SaveGame.SingletonRepository.Genders
                .Select(_gender => _gender.Title)
                .ToArray();
        }

        public override void RenderSelection(int index)
        {
            SaveGame.Screen.Print(Colour.Purple, "Your sex has no effect on gameplay.", 35, 21);
        }
    }
}