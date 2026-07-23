namespace AngbandOS.GamePacks.Cthangband;
    public class IronSkinPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(DexterityAttribute), "-1"),
        (nameof(BonusArmorClassAttribute), "25"),
    };
}