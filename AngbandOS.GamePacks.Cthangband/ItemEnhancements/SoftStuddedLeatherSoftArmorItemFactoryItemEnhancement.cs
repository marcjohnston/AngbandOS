namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SoftStuddedLeatherSoftArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "90"),
        (nameof(ValueAttribute), "35"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
        (nameof(BaseArmorClassAttribute), "5"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBrown;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
