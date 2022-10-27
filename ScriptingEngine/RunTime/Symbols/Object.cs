
namespace Big6Search.ScriptingEngine.RunTime
{
    public class ObjectSymbol : Symbol
    {

        public DataValue Value;
        public ObjectSymbol(string name) : base(name)
        {
        }
    }
    public partial class Symbol
    {
        public static bool IsObject(Symbol symbol)
        {
            return typeof(ObjectSymbol).IsAssignableFrom(symbol.GetType());
        }
    }
}