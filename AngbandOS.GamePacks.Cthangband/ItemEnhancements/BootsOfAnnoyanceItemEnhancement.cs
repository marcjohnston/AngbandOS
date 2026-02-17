namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BootsOfAnnoyanceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Aggravate => true;
    public override bool? Valueless => true;
    public override string? FriendlyName => "of Annoyance";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(SpeedAttribute), "1d10"),
        (nameof(ValueAttribute), "89000"),
    };
}
