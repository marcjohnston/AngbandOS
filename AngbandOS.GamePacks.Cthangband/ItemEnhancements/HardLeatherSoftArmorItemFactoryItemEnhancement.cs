namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HardLeatherSoftArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "100"),
        (nameof(ValueAttribute), "150"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "1"),
        (nameof(MeleeToHitAttribute), "-1"),
        (nameof(BaseArmorClassAttribute), "6"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBrown;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
