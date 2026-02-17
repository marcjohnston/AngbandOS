namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HatOfUglinessItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Valueless => true;
    public override string? FriendlyName => "of Ugliness";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "1d5"),
        (nameof(ValueAttribute), "1350"),
    };
}
