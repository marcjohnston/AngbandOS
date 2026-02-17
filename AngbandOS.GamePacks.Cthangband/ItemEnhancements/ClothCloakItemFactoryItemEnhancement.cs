namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ClothCloakItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Reflect => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "10"),
        (nameof(ValueAttribute), "3"),
        (nameof(BaseArmorClassAttribute), "1"),
    };
    public override ColorEnum? Color => ColorEnum.Green;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
