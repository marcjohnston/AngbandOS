namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SilverGoldItem : GoldItem
    {
        public SilverGoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<GoldSilver>()) { }
    }
}