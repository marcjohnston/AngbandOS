
namespace byMarc.Net2.Library.LanguageParsing
{
    public class SymbolToken : ParsedToken
    {

        public SymbolToken(string leadingWhiteSpace, string matchedText, int characterIndex) : base(leadingWhiteSpace, matchedText, characterIndex)
        {
        }
    }
}