namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RubiesGoldItem : GoldItem
    {
        public RubiesGoldItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<GoldRubies>()) { }
    }
}