namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfTheMagiItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? AdditionalItemEnhancementWeightedRandomBindingKey => nameof(AbilityItemEnhancementWeightedRandom);
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "7500"),
        (nameof(TreasureRatingAttribute), "15"),
        (nameof(IntelligenceAttribute), "1d3"),
    };
    public override string? FriendlyName => "of the Magi";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResAcid => true;
    public override bool? ResCold => true;
    public override bool? ResElec => true;
    public override bool? ResFire => true;
    public override bool? SustInt => true;
}
