namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel46ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResNexusAttribute), "true"),
    };
}