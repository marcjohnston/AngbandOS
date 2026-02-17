namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MithrilChainMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreAcid => true;
    public override bool? Reflect => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "150"),
        (nameof(ValueAttribute), "7000"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "4"),
        (nameof(MeleeToHitAttribute), "-1"),
        (nameof(BaseArmorClassAttribute), "28"),
    };
    public override ColorEnum? Color => ColorEnum.BrightBlue;
    public override string? HatesAcid => "true";
}
