namespace AngbandOS.GamePacks.Cthangband;
    public class BlankFaceMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(CharismaAttribute), "-1"),
    };
}