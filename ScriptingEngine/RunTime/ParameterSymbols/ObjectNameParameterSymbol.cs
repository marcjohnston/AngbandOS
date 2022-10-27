
namespace Big6Search.ScriptingEngine.RunTime
{
    public class ObjectNameParameterSymbol : ParameterSymbol
    {

        public readonly string ObjectName;
        public ObjectNameParameterSymbol(string objectName) : this(null, objectName)
        {
        }
        public ObjectNameParameterSymbol(DebugSymbol debugSymbol, string objectName) : base(debugSymbol)
        {
            ObjectName = objectName;
        }
    }
}