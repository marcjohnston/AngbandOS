namespace AngbandOS.Core.Expressions
{
    public class IntegerFactorParser : FactorParser
    {
        public readonly SymbolSet InitialDigits = new SymbolSet("+-0123456789");
        public readonly SymbolSet SubsequentDigits = new SymbolSet("0123456789");
        public IntegerFactorParser() { }
        public override Expression? TryParse(Parser parser, string text, ref int characterIndex)
        {
            int startCharacterIndex = characterIndex;
            char c = text[characterIndex];
            if (InitialDigits.Contains(c))
            {
                characterIndex++;
                while (text.Length > characterIndex && SubsequentDigits.Contains(text[characterIndex]))
                {
                    characterIndex++;
                }
                string integerText = text.Substring(startCharacterIndex, characterIndex - startCharacterIndex);
                if (!Int32.TryParse(integerText, out int integerValue))
                {
                    throw new Exception($"Invalid int32 value in expression \"{text}\" at position {characterIndex}.");
                }
                return new IntegerExpression(integerValue);
            }
            return null;
        }
    }
}
