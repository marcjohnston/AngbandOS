namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlayUndeadItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SlayUndead => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3500"),
    };
}
