
namespace byMarc.Net2.Library.LanguageParsing
{
    public class PositiveSignedWholeNumberToken : SignedWholeNumberToken
    {

        public PositiveSignedWholeNumberToken(string leadingWhiteSpace, string matchedText, int characterIndex, string signSymbol, string unsignedText) : base(leadingWhiteSpace, matchedText, characterIndex, signSymbol, unsignedText)
        {
        }
    }
}