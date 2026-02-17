namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MithrilPlateMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreAcid => true;
    public override bool? Reflect => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "300"),
        (nameof(ValueAttribute), "15000"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "4"),
        (nameof(MeleeToHitAttribute), "-3"),
        (nameof(BaseArmorClassAttribute), "35"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBlue;
    public override string? HatesAcid => "true";
}
