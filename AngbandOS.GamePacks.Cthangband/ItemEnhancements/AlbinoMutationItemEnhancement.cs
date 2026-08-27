namespace AngbandOS.GamePacks.Cthangband;

public class AlbinoMutationItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(BonusConstitutionAttribute), "-4"),
    };
}

