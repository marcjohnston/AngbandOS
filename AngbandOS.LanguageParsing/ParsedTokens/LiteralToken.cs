
namespace byMarc.Net2.Library.LanguageParsing
{
    public class LiteralToken : ParsedToken
    {

        public readonly string Literal;

        public LiteralToken(string leadingWhiteSpace, string matchedText, int characterIndex, string literal) : base(leadingWhiteSpace, matchedText, characterIndex)
        {
            Literal = literal;
        }
    }
}