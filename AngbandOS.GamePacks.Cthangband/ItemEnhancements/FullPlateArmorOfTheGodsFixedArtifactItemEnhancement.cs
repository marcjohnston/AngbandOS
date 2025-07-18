namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FullPlateArmorOfTheGodsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool Con => true;
    public override string FriendlyName => "of the Gods";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusConstitutionRollExpression => "1";
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResConf => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResNexus => true;
    public override bool ResSound => true;
}