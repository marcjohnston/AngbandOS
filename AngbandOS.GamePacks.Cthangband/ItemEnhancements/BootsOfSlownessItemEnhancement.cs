namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BootsOfSlownessItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Valueless => true;
    public override string? FriendlyName => "of Slowness";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(SpeedAttribute), "1d5"),
        (nameof(ValueAttribute), "99000"),
    };
}
