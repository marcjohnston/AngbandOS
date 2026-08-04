namespace AngbandOS.GamePacks.Cthangband;
    public class ShortLegPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(SpeedAttribute), "-3"),
    };
}