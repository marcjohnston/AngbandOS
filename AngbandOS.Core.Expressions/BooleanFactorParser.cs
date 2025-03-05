namespace AngbandOS.Core.Expressions;

[Serializable]
public class BooleanFactorParser : FactorParser
{
    public override Expression? TryParse(Parser parser, string text, ref int characterIndex)
    {
        if (characterIndex + 4 <= text.Length && text.ToLower().Substring(characterIndex, 4) == "true")
        {
            characterIndex += 4;
            return new BooleanExpression(true);
        }
        else if (characterIndex + 5 <= text.Length && text.ToLower().Substring(characterIndex, 5) == "false")
        {
            characterIndex += 5;
            return new BooleanExpression(false);
        }
        return null;
    }
}