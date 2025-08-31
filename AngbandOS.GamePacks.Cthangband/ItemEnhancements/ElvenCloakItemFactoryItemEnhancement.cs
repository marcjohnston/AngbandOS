namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ElvenCloakItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? CanReflectBoltsAndArrows => true;
    public override int? Weight => 5;
    public override int? Value => 1500;
    public override ColorEnum? Color => ColorEnum.BrightGreen;
    public override string? BaseArmorClass => "4";
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
    public override string? BonusArmorClass => "4";
}
