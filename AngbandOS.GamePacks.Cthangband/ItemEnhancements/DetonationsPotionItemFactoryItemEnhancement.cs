namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DetonationsPotionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "4"),
        (nameof(ValueAttribute), "10000"),
        (nameof(DamageDiceAttribute), "25"),
        (nameof(DiceSidesAttribute), "25"),
    };
    public override string? HatesCold => "true";
}
