namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TelepathyItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Telepathy => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "12500"),
    };
}
