namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HardStuddedLeatherSoftArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "110"),
        (nameof(ValueAttribute), "200"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "2"),
        (nameof(MeleeToHitAttribute), "-1"),
        (nameof(BaseArmorClassAttribute), "7"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBrown;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
