
namespace Big6Search.ScriptingEngine
{
    public abstract partial class DataType : RunTime.RunTimeObject
    {

        public abstract DataValue CreateDataValue();

        public DataType(DebugSymbol debugSymbol) : base(debugSymbol)
        {
        }
    }
}