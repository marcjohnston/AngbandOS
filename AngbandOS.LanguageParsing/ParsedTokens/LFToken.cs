
namespace byMarc.Net2.Library.LanguageParsing
{
    public class LFToken : LineFeedToken
    {

        public LFToken(string leadingWhiteSpace, string matchedText, int characterIndex) : base(leadingWhiteSpace, matchedText, characterIndex)
        {
        }
    }
}