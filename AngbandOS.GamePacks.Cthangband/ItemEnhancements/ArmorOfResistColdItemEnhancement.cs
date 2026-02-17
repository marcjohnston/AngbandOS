namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ArmorOfResistColdItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "600"),
        (nameof(TreasureRatingAttribute), "12"),
    };
    public override string? FriendlyName => "of Resist Cold";
    public override bool? IgnoreCold => true;
    public override bool? ResCold => true;
}
