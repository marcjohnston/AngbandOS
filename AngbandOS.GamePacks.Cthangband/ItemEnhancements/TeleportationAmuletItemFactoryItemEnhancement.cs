namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TeleportationAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IsCursed => true;
    public override bool? EasyKnow => true;
    public override bool? Teleport => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "3"),
        (nameof(ValueAttribute), "250"),
    };
}
