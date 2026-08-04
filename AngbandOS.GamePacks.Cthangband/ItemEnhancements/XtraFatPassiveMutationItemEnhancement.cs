namespace AngbandOS.GamePacks.Cthangband;
    public class XtraFatPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(ConstitutionAttribute), "2"),
        (nameof(SpeedAttribute), "-2"),
    };
}