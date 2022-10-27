
namespace byMarc.Net2.Library.LanguageParsing
{
    public class MissingWholeUnsignedDecimalNumberToken : UnsignedDecimalNumberToken
    {

        public MissingWholeUnsignedDecimalNumberToken(string leadingWhiteSpace, string matchedText, int characterIndex) : base(leadingWhiteSpace, matchedText, characterIndex)
        {
        }
    }
}