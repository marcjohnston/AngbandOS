
namespace byMarc.Net2.Library.LanguageParsing
{
    public abstract class LineFeedToken : ParsedToken
    {

        public LineFeedToken(string leadingWhiteSpace, string matchedText, int characterIndex) : base(leadingWhiteSpace, matchedText, characterIndex)
        {
        }
    }
}