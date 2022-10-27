using byMarc.Net2.Library.LanguageParsing;

namespace Big6Search.ScriptingEngine
{

    /// <summary>
    /// Represents a class that can parse script commands into a RunTime Command object.
    /// </summary>
    /// <remarks></remarks>
    public abstract class CommandParser
    {
        protected DebugSymbol DebugSymbol(Parser parser)
        {
            return new DebugSymbol(_debugSymbolStart, parser.CurrentToken().EndCharacterIndex);
        }
        private int _debugSymbolStart;
        protected int DebugSymbolStart
        {
            get
            {
                return _debugSymbolStart;
            }
        }
        public RunTime.Command[] TryParse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            if (Peek(parser, scriptEngine, workEnvironment))
            {
                if (parser.CurrentTokenIndex == -1)
                {
                    _debugSymbolStart = 1;
                }
                else
                {
                    _debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                }
                return Parse(parser, scriptEngine, workEnvironment);
            }
            else
            {
                return null;
            }
        }
        protected abstract bool Peek(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment);
        protected abstract RunTime.Command[] Parse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment);
    }
}
