
namespace byMarc.Net2.Library.LanguageParsing
{

    public static class Languages
    {
        private static ParseLanguage _WordBreaker_language = null;
        public static ParseLanguage WordBreaker()
        {
            if (_WordBreaker_language == null)
            {
                _WordBreaker_language = new ParseLanguage();
                _WordBreaker_language.IgnoreLineFeeds = false;
                _WordBreaker_language.RecognizeDoubleQuoteLiterals = false;
                _WordBreaker_language.RecognizeSingleQuoteLiterals = false;
                _WordBreaker_language.RecognizeSignedNumbers = false;
                _WordBreaker_language.RecognizeDecimalNumbers = false;
                _WordBreaker_language.IdentifierSymbolSet.RemainingCharactersSymbolSet = new SymbolSet("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_*");
            }
            return _WordBreaker_language;
        }
    }
}