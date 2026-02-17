namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BlackMassDeathBookItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "30"),
        (nameof(ValueAttribute), "1000"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
    };
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? HatesFire => "true";
}
