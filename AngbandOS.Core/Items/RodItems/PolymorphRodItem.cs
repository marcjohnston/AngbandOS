namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PolymorphRodItem : RodItem
    {
        public PolymorphRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RodPolymorph>()) { }
    }
}