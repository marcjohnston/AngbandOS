namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DisarmingWandItem : WandItem
    {
        public DisarmingWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandDisarming>()) { }
    }
}