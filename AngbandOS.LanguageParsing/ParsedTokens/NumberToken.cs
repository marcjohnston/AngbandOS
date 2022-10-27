
namespace byMarc.Net2.Library.LanguageParsing
{
    public class NumberToken : ParsedToken
    {

        public NumberToken(string leadingWhiteSpace, string matchedText, int characterIndex) : base(leadingWhiteSpace, matchedText, characterIndex)
        {
        }
    }
}