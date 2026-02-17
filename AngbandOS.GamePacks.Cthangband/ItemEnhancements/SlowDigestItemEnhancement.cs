namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlowDigestItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? SlowDigest => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ValueAttribute), "750"),
    };
}
