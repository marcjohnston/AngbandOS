namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfStupidityItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Valueless => true;
    public override string? FriendlyName => "of Stupidity";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(IntelligenceAttribute), "1d5"),
        (nameof(ValueAttribute), "3600"),
    };
}
