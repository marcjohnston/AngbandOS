namespace AngbandOS.GamePacks.Cthangband;
    public class XtraFatPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusConstitutionAttribute), "2"),
        (nameof(SpeedAttribute), "-2"),
    };
}