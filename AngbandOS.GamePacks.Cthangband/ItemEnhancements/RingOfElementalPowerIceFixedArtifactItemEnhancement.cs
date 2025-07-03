namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfElementalPowerIceFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Ring of Elemental Ice casts a coldball
    public override string? ActivationName => nameof(ActivationsEnum.LargeFrostBall200Every325p1d325DirectionalActivation);
    public override bool Cha => true;
    public override bool Con => true;
    public override int TreasureRating => 20;
    public override bool Dex => true;
    public override bool Feather => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Elemental Power (Ice)";
    public override bool HideType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImCold => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override string? BonusCharismaRollExpression => "2";
    public override string? BonusConstitutionRollExpression => "2";
    public override string? BonusIntelligenceRollExpression => "2";
    public override string? BonusDexterityRollExpression => "2";
    public override string? BonusSpeedRollExpression => "2";
    public override string? BonusStrengthRollExpression => "2";
    public override string? BonusWisdomRollExpression => "2";
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool Speed => true;
    public override bool Str => true;
    public override bool SustInt => true;
    public override bool SustWis => true;
    public override bool Wis => true;
    public override int Radius => 3;
    public override bool SlowDigest => true;
    public override bool Telepathy => true;
}