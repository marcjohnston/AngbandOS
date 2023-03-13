namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DrainLifeWandItem : WandItem
    {
        public DrainLifeWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandDrainLife>()) { }
    }
}