namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ArmorOfResistFireItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "800"),
        (nameof(TreasureRatingAttribute), "14"),
    };
    public override string? FriendlyName => "of Resist Fire";
    public override bool? IgnoreFire => true;
    public override bool? ResFire => true;
}
