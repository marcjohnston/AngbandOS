namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IocainePotionItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "4"),
        (nameof(DamageDiceAttribute), "20"),
        (nameof(DiceSidesAttribute), "20"),
    };
    public override string? HatesCold => "true";
    public override bool? Valueless => true;
}
