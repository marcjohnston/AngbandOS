namespace AngbandOS.Core.Items;

[Serializable]
internal class MithrilPlateMailHardArmorItem : HardArmorItem
{
    public MithrilPlateMailHardArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HardArmorMithrilPlateMail>()) { }
}