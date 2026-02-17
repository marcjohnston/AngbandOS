namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GlovesOfAgilityItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1000"),
        (nameof(TreasureRatingAttribute), "14"),
        (nameof(DexterityAttribute), "1d5"),
    };
    public override string? FriendlyName => "of Agility";
    public override bool? HideType => true;
}
