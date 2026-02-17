namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ShadowCloakItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ResDark => true;
    public override bool? ResLight => true;
    public override bool? Reflect => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "5"),
        (nameof(ValueAttribute), "7500"),
        (nameof(BonusArmorClassAttribute), "4"),
        (nameof(BaseArmorClassAttribute), "6"),
    };
    public override ColorEnum? Color => ColorEnum.Black;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
