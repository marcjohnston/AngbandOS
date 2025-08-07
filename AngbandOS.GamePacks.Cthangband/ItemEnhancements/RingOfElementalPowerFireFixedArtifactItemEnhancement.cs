namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfElementalPowerFireFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    // Ring of Elemental Fire casts a fireball
    public override string? ActivationName => nameof(ActivationsEnum.FireBall120r3Every225p1d225DirectionalActivation);
    public override bool Cha => true;
    public override bool Con => true;
    public override int TreasureRating => 20;
    public override bool Dex => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Elemental Power (Fire)";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImFire => true;
    public override bool Int => true;
    public override string? BonusCharismaRollExpression => "1";
    public override string? BonusConstitutionRollExpression => "1";
    public override string? BonusDexterityRollExpression => "1";
    public override string? BonusIntelligenceRollExpression => "1";
    public override string? BonusSpeedRollExpression => "1";
    public override string? BonusStrengthRollExpression => "1";
    public override string? BonusWisdomRollExpression => "1";
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override bool SlowDigest => true;
    public override bool Speed => true;
    public override bool Str => true;
    public override bool SustDex => true;
    public override bool SustStr => true;
    public override bool Wis => true;
    public override int Cost => 100000;
}
