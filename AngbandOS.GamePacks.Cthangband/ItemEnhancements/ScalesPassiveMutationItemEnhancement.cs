namespace AngbandOS.GamePacks.Cthangband;
    public class ScalesPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-1"),
        (nameof(BonusArmorClassAttribute), "10"),
    };
}