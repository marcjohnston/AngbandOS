namespace AngbandOS.GamePacks.Cthangband;
    public class WartSkinPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "-2"),
        (nameof(BonusArmorClassAttribute), "5"),
    };
}