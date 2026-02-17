namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BeginnersHandbookSorceryBookItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "30"),
        (nameof(ValueAttribute), "100"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBlue;
    public override string? HatesFire => "true";
}
