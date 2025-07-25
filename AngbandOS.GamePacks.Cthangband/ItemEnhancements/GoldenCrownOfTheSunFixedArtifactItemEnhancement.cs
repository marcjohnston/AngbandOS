namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GoldenCrownOfTheSunFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Sun Crown heals
    public override string? ActivationName => nameof(ActivationsEnum.Heal700Every25Activation);
    public override bool Con => true;
    public override int TreasureRating => 20;
    public override string FriendlyName => "of the Sun";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    /// <summary>
    /// Returns a value of 3 to add to the radius of light for a golden crown which provides no light.
    /// </summary>
    public override int Radius => 3;

    public override string? BonusConstitutionRollExpression => "3";
    public override string? BonusSpeedRollExpression => "3";
    public override string? BonusStrengthRollExpression => "3";
    public override string? BonusWisdomRollExpression => "3";
    public override bool Regen => true;
    public override bool ResBlind => true;
    public override bool ResChaos => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool Speed => true;
    public override bool Str => true;
    public override bool Wis => true;
    public override bool Feather => true;
    public override bool FreeAct => true;
    public override bool HoldLife => true;
    public override bool SlowDigest => true;
    public override bool Telepathy => true;
}