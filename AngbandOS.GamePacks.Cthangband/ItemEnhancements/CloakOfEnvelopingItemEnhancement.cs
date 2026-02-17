namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloakOfEnvelopingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Valueless => true;
    public override string? FriendlyName => "of Enveloping";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ToDamageAttribute), "1d10"),
        (nameof(MeleeToHitAttribute), "1d10"),
    };
    public override bool? ShowMods => true;
}
