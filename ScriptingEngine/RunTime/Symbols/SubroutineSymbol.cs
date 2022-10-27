
namespace Big6Search.ScriptingEngine.RunTime
{
    public class SubroutineSymbol : Symbol
    {

        public ParameterDefinition[] Parameters;
        public Command[] Commands;
        public SubroutineSymbol(string name) : base(name)
        {
        }
    }
    public partial class Symbol
    {
        public static bool IsSubroutineSymbol(Symbol symbol)
        {
            return typeof(SubroutineSymbol).IsAssignableFrom(symbol.GetType());
        }
    }
}