namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GlovesOfPowerItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "2500"),
        (nameof(TreasureRatingAttribute), "22"),
        (nameof(MeleeToHitAttribute), "1d5"),
        (nameof(ToDamageAttribute), "1d5"),
        (nameof(StrengthAttribute), "1d5")
    };
    public override string? FriendlyName => "of Power";
    public override bool? HideType => true;
    public override bool? ShowMods => true;
}
