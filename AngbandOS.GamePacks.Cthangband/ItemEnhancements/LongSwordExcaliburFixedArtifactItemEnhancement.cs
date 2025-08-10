namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordExcaliburFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Excalibur shoots a frost ball
    public override string? ActivationName => nameof(ActivationsEnum.BallOfCold100r2Every300DirectionalActivation);
    public override bool BrandCold => true;
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Excalibur'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a long sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusSpeedRollExpression => "10";
    public override bool Regen => true;
    public override bool ResCold => true;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayTroll => true;
    public override bool SlayUndead => true;
    public override bool SlowDigest => true;
    public override int Cost => 300000;
    public override int DamageDice => 2;
}