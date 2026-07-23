namespace AngbandOS.GamePacks.Cthangband;
    public class WartSkinPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-2"),
        (nameof(BonusArmorClassAttribute), "5"),
    };
}