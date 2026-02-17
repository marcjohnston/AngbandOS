namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MonsterConfusionScrollItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "5"),
        (nameof(ValueAttribute), "30"),
    };
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
