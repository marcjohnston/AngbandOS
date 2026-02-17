namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SustainDexterityItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SustDex => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "850"),
    };
}
