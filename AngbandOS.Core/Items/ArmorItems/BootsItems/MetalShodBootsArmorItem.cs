namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MetalShodBootsItem : BootsArmorItem
    {
        public MetalShodBootsItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<MetalShodBootsItemFactory>()) { }
    }
}