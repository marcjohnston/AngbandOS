namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportationStaffItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 50;
    public override int? Value => 2000;
    public override int? DamageDice => 1;
    public override int? DiceSides => 2;
}
