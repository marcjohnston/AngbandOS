namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AmmoOfBackbitingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Valueless => true;
    public override string? FriendlyName => "of Backbiting";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ToDamageAttribute), "1d50"),
        (nameof(MeleeToHitAttribute), "1d50"),
    };
}