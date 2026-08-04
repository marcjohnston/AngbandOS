namespace AngbandOS.GamePacks.Cthangband;
    public class PunyPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(StrengthAttribute), "-4"),
    };
}