namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfSlayUndeadItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3500"),
        (nameof(TreasureRatingAttribute), "18"),
    };
    public override string? FriendlyName => "of Slay Undead";
    public override bool? SlayUndead => true;
    public override bool? HoldLife => true;
}
