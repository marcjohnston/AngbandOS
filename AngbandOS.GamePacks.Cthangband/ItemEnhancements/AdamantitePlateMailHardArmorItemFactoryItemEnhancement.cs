namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AdamantitePlateMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreAcid => true;
    public override bool? Reflect => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "420"),
        (nameof(ValueAttribute), "20000"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "4"),
        (nameof(BaseArmorClassAttribute), "40"),
        (nameof(MeleeToHitAttribute), "-4"),
    };
    public override ColorEnum? Color => ColorEnum.BrightGreen;
    public override string? HatesAcid => "true";
}
