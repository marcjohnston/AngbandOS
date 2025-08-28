namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LightCrossbowOfDeathFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    // Death brands your bolts
    public override string? ActivationName => nameof(ActivationsEnum.BrandBoltsEvery999Activation);
    public override string FriendlyName => "of Death";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? BonusSpeedRollExpression => "10";
    public override bool? ResFire => true;
    public override bool? ShowMods => true;
    public override bool? XtraMight => true;
    public override int? Value => 50000;
    public override string BonusHitsRollExpression => "10";
    public override string BonusDamageRollExpression => "14";
    public override ColorEnum? Color => ColorEnum.Grey;
}
