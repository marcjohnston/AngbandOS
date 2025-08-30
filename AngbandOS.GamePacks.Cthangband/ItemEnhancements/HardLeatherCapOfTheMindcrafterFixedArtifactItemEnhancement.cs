namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HardLeatherCapOfTheMindcrafterFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? TreasureRating => 10;
    public override string FriendlyName => "of the Mindcrafter";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override string? Intelligence => "2";
    public override string? Wisdom => "2";
    public override bool? ResBlind => true;
    public override bool? Telepathy => true;
    public override int? Value => 50000;
    public override string Attacks => "10";
    public override ColorEnum? Color => ColorEnum.Brown;
}
