namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GlovesOfClumsinessItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Valueless => true;
    public override string? FriendlyName => "of Clumsiness";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
       (nameof(DexterityAttribute), "1d10"),
    };
}
