namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DragonsFrostWandItem : WandItem
    {
        public DragonsFrostWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandDragonsFrost>()) { }
    }
}