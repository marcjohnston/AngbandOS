namespace AngbandOS.Core.Expressions;

public class IntegerFactorParser : FactorParser
{
    public readonly SymbolSet InitialDigits = new SymbolSet("+-0123456789");
    public readonly SymbolSet SubsequentDigits = new SymbolSet("0123456789");
    public IntegerFactorParser() { }
    public override Expression? TryParse(ExpressionParser parser, string text, ref int characterIndex)
    {
        int currentCharacterIndex = characterIndex;
        char c = text[currentCharacterIndex];
        if (InitialDigits.Contains(c))
        {
            currentCharacterIndex++;
            while (currentCharacterIndex < text.Length && SubsequentDigits.Contains(text[currentCharacterIndex]))
            {
                currentCharacterIndex++;
            }
            string integerText = text.Substring(characterIndex, currentCharacterIndex - characterIndex);
            if (!Int32.TryParse(integerText, out int integerValue))
            {
                throw new Exception($"Invalid int32 value in expression \"{text}\" at position {characterIndex}.");
            }
            characterIndex = currentCharacterIndex; // Register the consumption of the decimal.
            return new IntegerExpression(integerValue);
        }
        return null;
    }
}
