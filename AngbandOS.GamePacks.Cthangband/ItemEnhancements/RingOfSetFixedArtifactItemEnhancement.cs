namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RingOfSetFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BizarreThingsEvery1d450p450DirectionalActivation);
    public override bool Aggravate => true;
    public override int TreasureRating => 20;
    public override bool IsCursed => true;
    public override bool DrainExp => true;
    public override bool DreadCurse => true;
    public override string FriendlyName => "of Set";
    public override bool HeavyCurse => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImAcid => true;
    public override bool ImCold => true;
    public override bool ImElec => true;
    public override bool ImFire => true;
    public override bool PermaCurse => true;
    public override string? BonusCharismaRollExpression => "5";
    public override string? BonusConstitutionRollExpression => "5";
    public override string? BonusDexterityRollExpression => "5";
    public override string? BonusIntelligenceRollExpression => "5";
    public override string? BonusSpeedRollExpression => "5";
    public override string? BonusStrengthRollExpression => "5";
    public override string? BonusWisdomRollExpression => "5";
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override bool SustCha => true;
    public override bool SustCon => true;
    public override bool SustDex => true;
    public override bool SustInt => true;
    public override bool SustStr => true;
    public override bool SustWis => true;
    public override bool Feather => true;
    public override bool FreeAct => true;
    public override bool HoldLife => true;
    public override int Radius => 3;
    public override bool SlowDigest => true;
    public override bool Telepathy => true;
    public override int Value => 5000000;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
    public override string BonusHitsRollExpression => "15";
    public override string BonusDamageRollExpression => "15";
    public override ColorEnum Color => ColorEnum.Yellow;
}
