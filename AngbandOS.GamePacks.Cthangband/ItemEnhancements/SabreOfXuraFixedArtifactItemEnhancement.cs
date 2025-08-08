namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SabreOfXuraFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool Blessed => true;
    public override bool BrandCold => true;
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Xura";
    public override bool HideType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusConstitutionRollExpression => "4";
    public override string? BonusDexterityRollExpression => "4";
    public override string? BonusStrengthRollExpression => "4";
    public override bool Regen => true;
    public override bool ResChaos => true;
    public override bool ResCold => true;
    public override bool ResFear => true;
    public override bool ResNether => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override int SlayDragon => 3;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override bool SlowDigest => true;
    public override bool SustCon => true;
    public override bool SustStr => true;
    public override int Cost => 125000;
}
