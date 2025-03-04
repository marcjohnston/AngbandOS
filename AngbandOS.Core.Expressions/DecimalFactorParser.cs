namespace AngbandOS.Core.Expressions;

public class DecimalFactorParser : FactorParser
{
    public readonly SymbolSet SignsDigits = new SymbolSet("+-");
    public readonly SymbolSet NumericDigits = new SymbolSet("0123456789");
    public readonly SymbolSet DecimalDigits = new SymbolSet(".");
    public DecimalFactorParser() { }
    public override Expression? TryParse(Parser parser, string text, ref int characterIndex)
    {
        int currentCharacterIndex = characterIndex;
        if (SignsDigits.Contains(text[currentCharacterIndex]))
        {
            currentCharacterIndex++;
        }

        while (currentCharacterIndex < text.Length && NumericDigits.Contains(text[currentCharacterIndex]))
        {
            currentCharacterIndex++;
        }

        if (currentCharacterIndex < text.Length && DecimalDigits.Contains(text[currentCharacterIndex]))
        {
            currentCharacterIndex++;
            while (currentCharacterIndex < text.Length && NumericDigits.Contains(text[currentCharacterIndex]))
            {
                currentCharacterIndex++;
            }

            string decimalText = text.Substring(characterIndex, currentCharacterIndex - characterIndex);
            if (!Double.TryParse(decimalText, out double decimalValue))
            {
                throw new Exception($"Invalid double value in expression \"{text}\" at position {characterIndex}.");
            }
            characterIndex = currentCharacterIndex; // Register the consumption of the decimal.
            return new DecimalExpression(decimalValue);
        }

        // This was not a decimal value.  It may have been an integer.
        return null;
    }
}
