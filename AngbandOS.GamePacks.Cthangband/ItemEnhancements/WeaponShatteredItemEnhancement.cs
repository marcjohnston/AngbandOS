namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaponShatteredItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Valueless => true;
    public override string? FriendlyName => "(Shattered)";
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ToDamageAttribute), "1d5"),
        (nameof(MeleeToHitAttribute), "1d5"),
    };
}
