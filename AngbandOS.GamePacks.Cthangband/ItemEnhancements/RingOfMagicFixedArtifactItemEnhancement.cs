namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfMagicFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Ring of Magic has a djinn in it that drains life from an opponent
    public override string? ActivationName => nameof(ActivationsEnum.DrainLife100Every100p1d100DirectionalActivation);
    public override int TreasureRating => 20;
    public override string FriendlyName => "of Magic";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusCharismaRollExpression => "1";
    public override string? BonusConstitutionRollExpression => "1";
    public override string? BonusDexterityRollExpression => "1";
    public override string? BonusIntelligenceRollExpression => "1";
    public override string? BonusSearchRollExpression => "1";
    public override string? BonusStealthRollExpression => "1";
    public override string? BonusWisdomRollExpression => "1";
    public override string? BonusStrengthRollExpression => "1";
    public override bool ResPois => true;
    public override bool SeeInvis => true;
    public override int Value => 75000;
}
