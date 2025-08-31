namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DarknessStaffItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 50;
    public override int? DamageDice => 1;
    public override int? DiceSides => 2;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
    public override bool? Valueless => true;
}
