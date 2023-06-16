namespace AngbandOS.Core.Items;

[Serializable]
internal class HardLeatherBootsArmorItem : BootsArmorItem
{
    public HardLeatherBootsArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HardLeatherBootsArmorItemFactory>()) { }
}