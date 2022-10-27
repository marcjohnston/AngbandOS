
namespace byMarc.Net2.Library.LanguageParsing
{
    public class SignedWholeNumberToken : WholeNumberToken, ISignedNumberToken
    {

        private readonly string _signSymbol;
        private readonly string _unsignedText;

        public string SignSymbol
        {
            get
            {
                return _signSymbol;
            }
        }

        public string UnsignedText
        {
            get
            {
                return _unsignedText;
            }
        }
        public SignedWholeNumberToken(string leadingWhiteSpace, string matchedText, int characterIndex, string signSymbol, string unsignedText) : base(leadingWhiteSpace, matchedText, characterIndex)
        {
            _signSymbol = signSymbol;
            _unsignedText = unsignedText;
        }
    }
}