namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DaggerIcicleFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    // Icicle shoots a cold ball
    public override string? ActivationName => nameof(ActivationsEnum.BallOfCold48r2Every5p1d5DirectionalActivation);
    public override bool Blows => true;
    public override bool BrandCold => true;
    public override bool BrandPois => true;
    public override string FriendlyName => "'Icicle'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusAttacksRollExpression => "2";
    public override string? BonusDexterityRollExpression => "2";
    public override string? BonusSpeedRollExpression => "2";
    public override bool Regen => true;
    public override bool ResCold => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlowDigest => true;
    public override int Cost => 50000;
    public override int DamageDice => 1;
    public override string BonusHitsRollExpression => "6";
    public override string BonusDamageRollExpression => "9";
}
