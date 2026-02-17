namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MagiAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TreasureRatingAttribute), "25"),
        (nameof(BonusArmorClassAttribute), "3"),
        (nameof(ValueAttribute), "30000"),
        (nameof(WeightAttribute), "3"),
    };
    public override bool? FreeAct => true;
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? SeeInvis => true;
}
