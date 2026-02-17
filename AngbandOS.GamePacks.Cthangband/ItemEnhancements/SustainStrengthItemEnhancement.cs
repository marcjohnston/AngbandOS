namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SustainStrengthItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SustStr => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "850"),
    };
}
