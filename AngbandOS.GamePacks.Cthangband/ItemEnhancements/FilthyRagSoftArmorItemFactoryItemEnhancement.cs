namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FilthyRagSoftArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "20"),
        (nameof(ValueAttribute), "1"),
        (nameof(BonusArmorClassAttribute), "-1"),
        (nameof(BaseArmorClassAttribute), "1"),
    };
    public override ColorEnum? Color => ColorEnum.Black;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
