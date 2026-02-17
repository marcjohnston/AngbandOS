namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GauntletGlovesItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "25"),
        (nameof(ValueAttribute), "35"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
        (nameof(BaseArmorClassAttribute), "2"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBrown;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
