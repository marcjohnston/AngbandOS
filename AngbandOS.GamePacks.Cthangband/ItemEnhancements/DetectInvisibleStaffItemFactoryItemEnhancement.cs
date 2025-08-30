namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DetectInvisibleStaffItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 50;
    public override int? Value => 200;
    public override int? DamageDice => 1;
    public override int? DiceSides => 2;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
