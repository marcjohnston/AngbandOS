namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LordlyProtectionRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "5"),
        (nameof(ValueAttribute), "100000"),
        (nameof(WeightAttribute), "2"),
    };
    public override bool? FreeAct => true;
    public override bool? HoldLife => true;
    public override bool? ResDisen => true;
    public override bool? ResPois => true;
    public override string? HatesElectricity => "true";
}
