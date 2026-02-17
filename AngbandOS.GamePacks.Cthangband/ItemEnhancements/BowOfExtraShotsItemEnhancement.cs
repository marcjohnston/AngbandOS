namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BowOfExtraShotsItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "10000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(MeleeToHitAttribute), "1d10"),
        (nameof(ToDamageAttribute), "1d5"),
    };
    public override string? FriendlyName => "of Extra Shots";
    public override bool? XtraShots => true;
}
