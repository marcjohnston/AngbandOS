using System.Collections.Generic;

namespace byMarc.Net2.Library.LanguageParsing
{
    public class ParseLanguage
    {
        public bool AllowLiteralToSpanMultipleLines { get; set; } = false;
        public bool IgnoreLineFeeds { get; set; } = true;
        public bool RecognizeSingleQuoteLiterals { get; set; } = false;
        public bool RecognizeDoubleQuoteLiterals { get; set; } = true;
        public bool RecognizeSignedNumbers { get; set; } = true;
        public bool RecognizeMissingWholeValuesOnDecimals { get; set; } = true;
        public bool RecognizeDecimalNumbers { get; set; } = true;
        public List<string> DefinedSymbols { get; set; } = new List<string>() { "<>", "<=", ">=", "=<", "=>" };
        public IdentifierSymbolSet IdentifierSymbolSet { get; set; } = new IdentifierSymbolSet(new SymbolSet("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_"), new SymbolSet("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_"));
        // Public LiteralDelimiters As New List(Of LiteralDelimiters) From {New LiteralDelimiters("'"), New LiteralDelimiters("""")} NOT IMPLEMENTED YET
    }
}