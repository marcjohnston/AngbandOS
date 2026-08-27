namespace AngbandOS.GamePacks.Cthangband;
    public class MagicResPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(SavingThrowAttribute), "15+X/5"),
    };
}