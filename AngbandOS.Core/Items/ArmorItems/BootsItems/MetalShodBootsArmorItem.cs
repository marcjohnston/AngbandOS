namespace AngbandOS.Core.Items;

[Serializable]
internal class MetalShodBootsArmorItem : BootsArmorItem
{
    public MetalShodBootsArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<MetalShodBootsArmorItemFactory>()) { }
}