namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronCrownOfMiseryFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool Con => true;
    public override bool IsCursed => true;
    public override bool Dex => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Misery";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusConstitutionRollExpression => "-25";
    public override string? BonusDexterityRollExpression => "-25";
    public override string? BonusStrengthRollExpression => "-25";
    public override bool SeeInvis => true;
    public override bool Str => true;
    public override bool Telepathy => true;
    public override bool Feather => true;
    public override bool HoldLife => true;
    public override int Radius => 3;
    public override bool Regen => true;
    public override bool SlowDigest => true;
}