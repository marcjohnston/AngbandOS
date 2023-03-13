namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SapphiresGoldItem : GoldItem
    {
        public SapphiresGoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<GoldSapphires>()) { }
    }
}