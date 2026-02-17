namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TerribleWeaponOfDiggingItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Valueless => true;
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(TunnelAttribute), "-1d5+5"),
        (nameof(ValueAttribute), "1125"),
    };
}
