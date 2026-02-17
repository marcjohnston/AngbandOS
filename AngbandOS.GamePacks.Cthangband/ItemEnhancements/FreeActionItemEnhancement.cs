namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FreeActionItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? FreeAct => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "4500"),
    };
}
