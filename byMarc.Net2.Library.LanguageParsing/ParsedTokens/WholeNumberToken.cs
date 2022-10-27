
namespace byMarc.Net2.Library.LanguageParsing
{
    public class WholeNumberToken : NumberToken
    {

        public WholeNumberToken(string leadingWhiteSpace, string matchedText, int characterIndex) : base(leadingWhiteSpace, matchedText, characterIndex)
        {
        }
    }
}