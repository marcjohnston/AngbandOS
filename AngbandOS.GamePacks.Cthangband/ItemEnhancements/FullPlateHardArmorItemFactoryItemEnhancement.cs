namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FullPlateHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Reflect => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "380"),
        (nameof(ValueAttribute), "1350"),
        (nameof(DamageDiceAttribute), "2"),
        (nameof(DiceSidesAttribute), "4"),
        (nameof(MeleeToHitAttribute), "-3"),
        (nameof(BaseArmorClassAttribute), "25"),
    };
    public override ColorEnum? Color => ColorEnum.BrightWhite;
    public override string? HatesAcid => "true";
}
