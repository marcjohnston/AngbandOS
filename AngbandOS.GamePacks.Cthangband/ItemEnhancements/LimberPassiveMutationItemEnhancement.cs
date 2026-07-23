namespace AngbandOS.GamePacks.Cthangband;
    public class LimberPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(DexterityAttribute), "3"),
    };
}