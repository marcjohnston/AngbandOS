namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HardLeatherCapHelmItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Reflect => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "15"),
        (nameof(ValueAttribute), "12"),
        (nameof(BaseArmorClassAttribute), "2"),
    };
    public override ColorEnum? Color => ColorEnum.Brown;
    public override string? HatesAcid => "true";
}
