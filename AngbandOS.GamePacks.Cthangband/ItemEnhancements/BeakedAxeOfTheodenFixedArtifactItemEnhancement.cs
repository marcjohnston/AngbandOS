namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BeakedAxeOfTheodenFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 10;
    // Theoden drains life
    public override string? ActivationName => nameof(ActivationsEnum.DrainLife120Every400DirectionalActivation);
    public override string FriendlyName => "of Theoden";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override string? BonusConstitutionRollExpression => "3";
    public override string? BonusWisdomRollExpression => "3";
    public override bool ShowMods => true;
    public override int SlayDragon => 3;
    public override bool SlowDigest => true;
    public override bool Telepathy => true;
    public override int Value => 40000;
    public override string BonusHitsRollExpression => "8";
    public override string BonusDamageRollExpression => "10";
    public override ColorEnum? Color => ColorEnum.Grey;
}
