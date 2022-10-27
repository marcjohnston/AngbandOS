using Microsoft.VisualBasic;

namespace Big6Search.ScriptingEngine
{

    public class DebugSymbol
    {
        public readonly int CharacterIndex;
        public readonly int Length;

        public DebugSymbol(int startCharacterIndex, int endCharacterIndex)
        {
            CharacterIndex = startCharacterIndex;
            Length = endCharacterIndex - startCharacterIndex + 1;
        }
        public DebugSymbol(int startCharacterIndex, string matchedText)
        {
            CharacterIndex = startCharacterIndex;
            Length = Strings.Len(matchedText);
        }
    }
}