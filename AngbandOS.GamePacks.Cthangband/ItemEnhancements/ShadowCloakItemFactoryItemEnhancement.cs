namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShadowCloakItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResDark => true;
    public override bool? ResLight => true;
    public override bool? CanReflectBoltsAndArrows => true;
    public override int? Weight => 5;
    public override int? Value => 7500;
    public override ColorEnum? Color => ColorEnum.Black;
    public override string? BaseArmorClass => "6";
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
