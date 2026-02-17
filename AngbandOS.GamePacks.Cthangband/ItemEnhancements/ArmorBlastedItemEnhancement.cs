namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ArmorBlastedItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Valueless => true;
    public override string? FriendlyName => "(Blasted)";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusArmorClassAttribute), "1d10"),
    };
}
