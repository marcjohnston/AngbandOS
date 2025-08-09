namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LongSwordVorpalBladeFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Vorpal Blade'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a long sword which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusDexterityRollExpression => "2";
    public override string? BonusSpeedRollExpression => "2";
    public override string? BonusStrengthRollExpression => "2";
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override bool SlayEvil => true;
    public override bool SlowDigest => true;
    public override bool Vorpal => true;
    public override int Weight => 20;
    public override int Cost => 250000;
    public override int DamageDice => 5;
}
