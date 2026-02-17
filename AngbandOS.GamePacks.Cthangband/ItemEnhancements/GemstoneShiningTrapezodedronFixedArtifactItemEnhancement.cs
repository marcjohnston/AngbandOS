namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GemstoneShiningTrapezodedronFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.TrapezohedronGemstoneActivation);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(ValueAttribute), "150000"),
        (nameof(WisdomAttribute), "3"),
        (nameof(SpeedAttribute), "3"),
        (nameof(IntelligenceAttribute), "3"),
    };
    public override string FriendlyName => "'Shining Trapezodedron'";
    public override bool? HoldLife => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResChaos => true;
    public override bool? SeeInvis => true;
    public override ColorEnum? Color => ColorEnum.Red;
}
