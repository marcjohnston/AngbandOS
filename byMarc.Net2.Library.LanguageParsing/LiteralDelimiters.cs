
namespace byMarc.Net2.Library.LanguageParsing
{
    public class LiteralDelimiters
    {
        public readonly string LeadingLiteralDelimiter;
        public readonly string TrailingLiteralDelimiter;
        public LiteralDelimiters(string leadingLiteralDelimiter, string trailingLiteralDelimiter)
        {
            LeadingLiteralDelimiter = leadingLiteralDelimiter;
            TrailingLiteralDelimiter = trailingLiteralDelimiter;
        }
        public LiteralDelimiters(string bothLeadingAndTrailingLiteralDelimiters)
        {
            LeadingLiteralDelimiter = bothLeadingAndTrailingLiteralDelimiters;
            TrailingLiteralDelimiter = bothLeadingAndTrailingLiteralDelimiters;
        }
    }
}