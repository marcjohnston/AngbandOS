namespace AngbandOS.Core.BirthStages
{
    internal class RaceSelectionBirthStage : BaseBirthStage
    {
        private RaceSelectionBirthStage(SaveGame saveGame) : base(saveGame) { }
        public override string[] GetMenu()
        {
            return SaveGame.SingletonRepository.Races
                .OrderBy((Race race) => race.Title)
                .Select((Race race) => race.Title)
                .ToArray();
        }
    }
}