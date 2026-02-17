namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MetalLamellarHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Reflect => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "340"),
        (nameof(ValueAttribute), "1250"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "6"),
        (nameof(MeleeToHitAttribute), "-3"),
        (nameof(BaseArmorClassAttribute), "23"),
    };
    public override ColorEnum? Color => ColorEnum.BrightWhite;
    public override string? HatesAcid => "true";
}
