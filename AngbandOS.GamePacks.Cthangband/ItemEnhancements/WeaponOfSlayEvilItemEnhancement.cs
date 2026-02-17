namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfSlayEvilItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "3500"),
        (nameof(TreasureRatingAttribute), "18"),
    };
    public override string? FriendlyName => "of Slay Evil";
    public override bool? SlayEvil => true;
}
