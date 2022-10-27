
namespace byMarc.Net2.Library.LanguageParsing
{
    public class NegativeSignedWholeNumberToken : SignedWholeNumberToken
    {

        public NegativeSignedWholeNumberToken(string leadingWhiteSpace, string matchedText, int characterIndex, string signSymbol, string unsignedText) : base(leadingWhiteSpace, matchedText, characterIndex, signSymbol, unsignedText)
        {
        }
    }
}