namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PolymorphWandItem : WandItem
    {
        public PolymorphWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<WandPolymorph>()) { }
    }
}