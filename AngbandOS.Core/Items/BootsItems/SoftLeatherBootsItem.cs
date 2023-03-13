namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SoftLeatherBootsItem : BootsItem
    {
        public SoftLeatherBootsItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<BootsSoftLeatherBoots>()) { }
    }
}