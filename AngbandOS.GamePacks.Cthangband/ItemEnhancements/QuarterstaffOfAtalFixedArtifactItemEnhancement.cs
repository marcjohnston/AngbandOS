namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class QuarterstaffOfAtalFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Atal does full identify
    public override string? ActivationName => nameof(ActivationsEnum.ProbingDetectionAndFullIdEvery1000Activation);
    public override bool BrandFire => true;
    public override int TreasureRating => 20;
    public override string FriendlyName => "of Atal";
    public override bool HideType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a quarterstaff which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusCharismaRollExpression => "4";
    public override string? BonusIntelligenceRollExpression => "4";
    public override string? BonusWisdomRollExpression => "4";
    public override bool ResFire => true;
    public override bool ResNether => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayEvil => true;
    public override bool SlayOrc => true;
    public override bool SlayTroll => true;
    public override bool Feather => true;
    public override bool FreeAct => true;
    public override bool Regen => true;
    public override bool SlowDigest => true;
    public override bool Telepathy => true;
    public override int Cost => 140000;
    public override int DamageDice => 1;
    public override string BonusHitRollExpression => "10";
    public override string BonusDamageRollExpression => "13";
}
