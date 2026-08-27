namespace AngbandOS.GamePacks.Cthangband;

public class MonkCharacterClassLevel10ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string Expression)[]? SummationAttributeAndExpressionBindings => new (string AttributeName, string Expression)[]
    {
        (nameof(SpeedAttribute), "1")
    };
}
