namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HardLeatherCapOfTheMindcrafterFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "10"),
        (nameof(ValueAttribute), "50000"),
        (nameof(WisdomAttribute), "2"),
        (nameof(IntelligenceAttribute), "2"),
    };
    public override string FriendlyName => "of the Mindcrafter";
    public override bool? HideType => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResBlind => true;
    public override bool? Telepathy => true;
    public override ColorEnum? Color => ColorEnum.Brown;
}
