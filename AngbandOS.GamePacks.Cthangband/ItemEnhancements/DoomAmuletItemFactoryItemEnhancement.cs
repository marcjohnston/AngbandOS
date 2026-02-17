namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DoomAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IsCursed => true;
    public override bool? HideType => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(WeightAttribute), "3"),
        (nameof(ValueAttribute), "-5000"),
    };
    public override bool? Valueless => true;
}
