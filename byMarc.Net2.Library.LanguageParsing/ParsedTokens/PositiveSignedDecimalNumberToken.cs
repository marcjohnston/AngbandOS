
namespace byMarc.Net2.Library.LanguageParsing
{
    public class PositiveSignedDecimalNumberToken : SignedDecimalNumberToken
    {

        public PositiveSignedDecimalNumberToken(string leadingWhiteSpace, string matchedText, int characterIndex, string signSymbol, string unsignedText) : base(leadingWhiteSpace, matchedText, characterIndex, signSymbol, unsignedText)
        {
        }
    }
}