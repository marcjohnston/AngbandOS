
namespace byMarc.Net2.Library.LanguageParsing
{
    public class NegativeSignedDecimalNumberToken : SignedDecimalNumberToken
    {

        public NegativeSignedDecimalNumberToken(string leadingWhiteSpace, string matchedText, int characterIndex, string signSymbol, string unsignedText) : base(leadingWhiteSpace, matchedText, characterIndex, signSymbol, unsignedText)
        {
        }
    }
}