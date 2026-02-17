namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfElectricityItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "4000"),
        (nameof(TreasureRatingAttribute), "16"),
        (nameof(BonusArmorClassAttribute), "1d4"),
    };
    public override string? FriendlyName => "of Electricity";
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreElec => true;
    public override bool? ResElec => true;
    public override bool? ShElec => true;
}
