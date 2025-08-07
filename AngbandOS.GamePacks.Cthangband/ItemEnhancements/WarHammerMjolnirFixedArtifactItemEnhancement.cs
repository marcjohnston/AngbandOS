namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WarHammerMjolnirFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool BrandElec => true;
    public override int TreasureRating => 20;
    public override bool FreeAct => true;
    public override string FriendlyName => "'Mjolnir'";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool KillDragon => true;
    public override string? BonusWisdomRollExpression => "4";
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResNexus => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override bool Wis => true;
    public override bool Feather => true;
    public override bool HoldLife => true;
    public override int Radius => 3;
    public override bool Regen => true;
    public override bool SlowDigest => true;
    public override bool Telepathy => true;
    public override int Cost => 250000;
}
