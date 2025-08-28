namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PowerStaffItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 50;
    public override int? Value => 4000;
    public override int? DamageDice => 1;
    public override int? DiceSides => 2;
}
