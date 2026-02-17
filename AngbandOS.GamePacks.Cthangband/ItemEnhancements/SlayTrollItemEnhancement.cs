namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlayTrollItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SlayTroll => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3500"),
    };
}
