namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfProtectionItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "500"),
        (nameof(TreasureRatingAttribute), "10"),
        (nameof(BonusArmorClassAttribute), "1d10"),
    };
    public override string? FriendlyName => "of Protection";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
}
