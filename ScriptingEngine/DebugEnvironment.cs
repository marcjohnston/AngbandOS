
namespace Big6Search.ScriptingEngine
{
    public class DebugEnvironment
    {
        public readonly string Script;
        public readonly DebugSymbol[] Symbols;
        public DebugEnvironment(string script)
        {
            Script = script;
        }
    }
}