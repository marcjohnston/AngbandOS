namespace AngbandOS.Core.BirthStages
{
    [Serializable]
    internal class NamingBirthStage : BaseBirthStage
    {
        private NamingBirthStage(SaveGame saveGame) : base(saveGame) { }
        public override BaseBirthStage? Render()
        {
            if (string.IsNullOrEmpty(SaveGame.Player.Name))
            {
                SaveGame.Player.Name = SaveGame.Player.Race.CreateRandomName();
            }
            SaveGame.Player.InputPlayerName();
            return null;
        }
    }
}
