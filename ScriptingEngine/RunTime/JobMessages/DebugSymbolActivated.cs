
namespace Big6Search.ScriptingEngine.RunTime
{
    public class DebugSymbolActivated : JobMessage
    {
        public readonly DebugSymbol DebugSymbol;
        public DebugSymbolActivated(DebugSymbol debugSymbol)
        {
            DebugSymbol = debugSymbol;
        }
    }
}