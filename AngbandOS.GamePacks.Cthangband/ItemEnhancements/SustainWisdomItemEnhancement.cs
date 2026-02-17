namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SustainWisdomItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SustWis => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "850"),
    };
}
