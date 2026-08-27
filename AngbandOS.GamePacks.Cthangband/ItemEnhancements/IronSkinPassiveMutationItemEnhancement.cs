namespace AngbandOS.GamePacks.Cthangband;
    public class IronSkinPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusDexterityAttribute), "-1"),
        (nameof(BonusArmorClassAttribute), "25"),
    };
}