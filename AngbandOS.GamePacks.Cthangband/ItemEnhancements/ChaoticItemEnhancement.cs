namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChaoticItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Chaotic => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "10000"),
    };
}
