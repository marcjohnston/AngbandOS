namespace AngbandOS.Core.Items
{
[Serializable]
    internal class FrostBoltsWandItem : WandItem
    {
        public FrostBoltsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandFrostBolts>()) { }
    }
}