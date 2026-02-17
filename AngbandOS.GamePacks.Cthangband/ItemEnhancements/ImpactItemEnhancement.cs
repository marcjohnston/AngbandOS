namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ImpactItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Impact => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "5000"),
    };
}
