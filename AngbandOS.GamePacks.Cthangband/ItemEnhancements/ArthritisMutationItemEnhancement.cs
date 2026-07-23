namespace AngbandOS.GamePacks.Cthangband;
    public class ArthritisMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(DexterityAttribute), "-3"),
    };
}