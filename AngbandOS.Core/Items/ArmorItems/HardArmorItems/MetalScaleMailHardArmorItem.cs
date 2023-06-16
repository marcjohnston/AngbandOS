namespace AngbandOS.Core.Items;

[Serializable]
internal class MetalScaleMailHardArmorItem : HardArmorItem
{
    public MetalScaleMailHardArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HardArmorMetalScaleMail>()) { }
}