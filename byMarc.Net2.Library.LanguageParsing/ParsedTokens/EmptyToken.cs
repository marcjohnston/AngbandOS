
namespace byMarc.Net2.Library.LanguageParsing
{
    /// <summary>
/// The leading whitespace will always be nothing.
/// </summary>
/// <remarks></remarks>
    public class EmptyToken : ParsedToken
    {

        public EmptyToken(string matchedText, int characterIndex) : base(null, matchedText, characterIndex)
        {
        }
    }
}