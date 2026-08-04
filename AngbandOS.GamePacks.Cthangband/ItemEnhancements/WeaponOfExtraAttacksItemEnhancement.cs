namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponOfExtraAttacksItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "10000"),
        (nameof(TreasureRatingAttribute), "20"),
        (nameof(AttacksAttribute), "1d3"),
    };
    public override string? FriendlyName => "of Extra Attacks";
}
