namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SoftLeatherBootsItem : BootsArmorItem
    {
        public SoftLeatherBootsItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SoftLeatherBootsItemFactory>()) { }
    }
}