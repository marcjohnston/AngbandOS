namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GlovesOfSlayingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1500"),
        (nameof(TreasureRatingAttribute), "17"),
        (nameof(MeleeToHitAttribute), "1d6"),
        (nameof(ToDamageAttribute), "1d6"),
    };
    public override string? FriendlyName => "of Slaying";
    public override bool? ShowMods => true;
}
