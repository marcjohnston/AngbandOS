namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RustyChainMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Reflect => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "200"),
        (nameof(ValueAttribute), "550"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "4"),
        (nameof(MeleeToHitAttribute), "-5"),
        (nameof(BonusArmorClassAttribute), "-8"),
        (nameof(BaseArmorClassAttribute), "14"),
    };
    public override ColorEnum? Color => ColorEnum.Red;
    public override string? HatesAcid => "true";
}
