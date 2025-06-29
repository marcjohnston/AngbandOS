namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BeakedAxeOfTheodenFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    // Theoden drains life
    public override string? ActivationName => nameof(ActivationsEnum.DrainLife120Every400DirectionalActivation);
    public override bool Con => true;
    public override string FriendlyName => "of Theoden";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusConstitutionRollExpression => "3";
    public override string? BonusWisdomRollExpression => "3";
    public override bool ShowMods => true;
    public override bool SlayDragon => true;
    public override bool SlowDigest => true;
    public override bool Telepathy => true;
    public override bool Wis => true;
}