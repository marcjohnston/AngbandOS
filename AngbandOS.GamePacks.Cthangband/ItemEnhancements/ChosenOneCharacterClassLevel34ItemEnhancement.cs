namespace AngbandOS.GamePacks.Cthangband;
    public class ChosenOneCharacterClassLevel34ItemEnhancement : ItemEnhancementGameConfiguration
{
    public override (string AttributeName, string BooleanExpression)[]? BitwiseOrAttributeAndExpressionBindings => new (string AttributeName, string BooleanExpression)[]
    {
        (nameof(ResSoundAttribute), "true"),
    };
}