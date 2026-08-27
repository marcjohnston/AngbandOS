namespace AngbandOS.GamePacks.Cthangband;

public class IllNormPassiveMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusCharismaAttribute), "0-CHA+8+2*X"),
    };
}
