namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalBrigandineArmorOfSerpentsFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    public override bool Dex => true;
    public override string FriendlyName => "of Serpents";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusDexterityRollExpression => "2";
    public override string? BonusStrengthRollExpression => "2";
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResConf => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResSound => true;
    public override bool Str => true;
    public override int Weight => -90;
}