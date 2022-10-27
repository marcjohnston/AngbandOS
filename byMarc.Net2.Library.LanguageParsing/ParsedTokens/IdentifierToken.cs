
namespace byMarc.Net2.Library.LanguageParsing
{
    public class IdentifierToken : ParsedToken
    {

        public IdentifierToken(string leadingWhiteSpace, string matchedText, int characterIndex) : base(leadingWhiteSpace, matchedText, characterIndex)
        {
        }
    }
}