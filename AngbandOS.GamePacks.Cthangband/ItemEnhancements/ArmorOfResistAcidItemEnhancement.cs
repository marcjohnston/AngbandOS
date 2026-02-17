namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ArmorOfResistAcidItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "1000"),
        (nameof(TreasureRatingAttribute), "16"),
    };
    public override string? FriendlyName => "of Resist Acid";
    public override bool? IgnoreAcid => true;
    public override bool? ResAcid => true;
}
