namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StinkingCloudWandItem : WandItem
    {
        public StinkingCloudWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandStinkingCloud>()) { }
        public override void ApplyMagic(int level, int power)
        {
            TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
        }
    }
}