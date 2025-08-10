namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CutlassOfBlackbeardFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool Feather => true;
    public override string FriendlyName => "of Blackbeard";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusDexterityRollExpression => "3";
    public override string? BonusStealthRollExpression => "3";
    public override bool Regen => true;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override int Cost => 28000;
    public override string BonusHitRollExpression => "10";
    public override string BonusDamageRollExpression => "11";
}
