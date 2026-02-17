namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SeeInvisibleItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SeeInvis => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2000"),
    };
}
