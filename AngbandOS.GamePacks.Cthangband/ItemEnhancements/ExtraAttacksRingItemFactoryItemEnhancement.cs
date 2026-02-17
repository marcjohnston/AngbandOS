namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ExtraAttacksRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(AttacksAttribute), "1"),
        (nameof(WeightAttribute), "2"),
        (nameof(ValueAttribute), "100000"),
    };
    public override string? HatesElectricity => "true";
}
