namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShadowCloakOfNyogthaFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override string? ActivationName => nameof(ActivationsEnum.RestoreLifeLevelsEvery450DirectionalActivation);
    public override bool Cha => true;
    public override string FriendlyName => "of Nyogtha";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override string? BonusCharismaRollExpression => "2";
    public override string? BonusIntelligenceRollExpression => "2";
    public override string? BonusSpeedRollExpression => "2";
    public override string? BonusStealthRollExpression => "2";
    public override string? BonusWisdomRollExpression => "2";
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResFire => true;
    public override bool Speed => true;
    public override bool Stealth => true;
    public override bool Wis => true;
    public override int Cost => 55000;
}
