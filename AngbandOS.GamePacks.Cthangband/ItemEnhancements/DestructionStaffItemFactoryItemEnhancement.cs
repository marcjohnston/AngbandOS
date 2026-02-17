namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DestructionStaffItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "50"),
        (nameof(ValueAttribute), "2500"),
        (nameof(DamageDiceAttribute), "1"),
        (nameof(DiceSidesAttribute), "2"),
    };
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}
