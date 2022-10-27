using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    /// <summary>
/// Represents an exception that is thrown by the scripting engine during the compilation of a script.
/// </summary>
/// <remarks></remarks>
    public class SyntaxErrorScriptException : ScriptException
    {

        public readonly string MatchedText;
        public readonly int CharacterIndex;

        public SyntaxErrorScriptException(string message, ParsedToken parsedToken) : this(message, parsedToken.StartCharacterIndex, parsedToken.MatchedText)
        {
        }
        public SyntaxErrorScriptException(string message, int startCharacterIndex, string matchedText) : base(message)
        {
            CharacterIndex = startCharacterIndex;
            MatchedText = matchedText;
        }
    }
}