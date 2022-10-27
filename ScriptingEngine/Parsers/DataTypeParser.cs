using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    /// <summary>
/// Represents the base class to be used to install a new data type parser.  The SyntaxParser ParseDataType enumerates all of the installed data types during data type parsing.  Classes that inherit from this class must process the TryParse method.
/// </summary>
/// <remarks></remarks>
    public abstract class DataTypeParser
    {
        protected DebugSymbol DebugSymbol(Parser parser)
        {
            return new DebugSymbol(_debugSymbolStart, parser.CurrentToken().EndCharacterIndex);
        }
        private int _debugSymbolStart;
        public DataType TryParse(Parser parser, RunTime.WorkEnvironment workEnvironment)
        {
            if (Peek(parser, workEnvironment))
            {
                if (parser.CurrentTokenIndex == -1)
                {
                    _debugSymbolStart = 1;
                }
                else
                {
                    _debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                }
                return Parse(parser, workEnvironment);
            }
            else
            {
                return null;
            }
        }
        protected abstract bool Peek(Parser parser, RunTime.WorkEnvironment workEnvironment);
        protected abstract DataType Parse(Parser parser, RunTime.WorkEnvironment workEnvironment);
    }
}