
namespace byMarc.Net2.Library.LanguageParsing
{
    public enum TokenTypeEnum
    {
        Empty = 0,
        Identifer = 1,
        Number = 2,
        PredefinedWord = 4,
        Symbol = 8,
        Literal = 16,
        UnsignedWholeNumber = 32,
        SignedWholeNumber = 64,
        UnsignedDecimalNumber = 128,
        SignedDecimalNumber = 256,
        UnsignedDecimalNumberMissingWhole = 512,
        SignedDecimalNumberMissingWhole = 1024,
        CaseSensitivePredefinedWord = 2048,
        CaseInsensitivePredefinedWord = 4096,
        SignedNumber = 8192,
        LineFeed = 16384
    }
}