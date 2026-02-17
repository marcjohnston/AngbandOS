namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BlessedItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Blessed => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "13000"),
    };
}
