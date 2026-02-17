namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmmoOfHurtEvilItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "25"),
        (nameof(TreasureRatingAttribute), "10"),
    };
    public override string? FriendlyName => "of Hurt Evil";
    public override bool? SlayEvil => true;
}
