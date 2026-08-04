namespace AngbandOS.GamePacks.Cthangband;
    public class ArthritisMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(DexterityAttribute), "-3"),
    };
}