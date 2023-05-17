namespace AngbandOS.Core.BirthStages
{
    internal class ClassSelectionBirthStage : BaseBirthStage
    {
        private ClassSelectionBirthStage(SaveGame saveGame) : base(saveGame) { }
        public override string[] GetMenu()
        {
            return SaveGame.SingletonRepository.CharacterClasses
                .OrderBy(_characterClass => _characterClass.Title)
                .Select(_characterClass => _characterClass.Title)
                .ToArray();
        }
    }
}