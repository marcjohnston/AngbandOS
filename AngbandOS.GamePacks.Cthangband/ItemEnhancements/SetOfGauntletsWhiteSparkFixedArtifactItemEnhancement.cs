namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SetOfGauntletsWhiteSparkFixedArtifactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(AttacksAttribute), "15"),
        (nameof(ValueAttribute), "11000"),
    };
    public override string? ActivationName => nameof(ActivationsEnum.BoltOfElectricity4d8Every1d6p6DirectionalActivation);
    public override string FriendlyName => "'White Spark'";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResElec => true;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
