
namespace byMarc.Net2.Library.LanguageParsing
{
    public class MissingWholePositiveSignedDecimalNumberToken : PositiveSignedDecimalNumberToken
    {

        public MissingWholePositiveSignedDecimalNumberToken(string leadingWhiteSpace, string matchedText, int characterIndex, string signSymbol, string unsignedText) : base(leadingWhiteSpace, matchedText, characterIndex, signSymbol, unsignedText)
        {
        }
    }
}