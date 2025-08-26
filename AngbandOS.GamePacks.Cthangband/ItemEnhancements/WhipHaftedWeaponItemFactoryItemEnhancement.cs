namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WhipHaftedWeaponItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool ShowMods => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int Weight => 30;
    public override int Value => 30;
    public override int DamageDice => 1;
    public override int DiceSides => 6;
    public override ColorEnum Color => ColorEnum.Black;
}
