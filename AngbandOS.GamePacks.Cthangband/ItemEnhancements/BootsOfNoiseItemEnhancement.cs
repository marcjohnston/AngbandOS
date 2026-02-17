namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BootsOfNoiseItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Aggravate => true;
    public override bool? Valueless => true;
    public override string? FriendlyName => "of Noise";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "-10000"),
    };
}
