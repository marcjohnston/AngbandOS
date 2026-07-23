namespace AngbandOS.GamePacks.Cthangband;
    public class XtraEyesPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(SearchAttribute), "15"),
    };
}