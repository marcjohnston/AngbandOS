
namespace Big6Search.ScriptingEngine
{
    public class IntegerDataType : DataType
    {

        public override DataValue CreateDataValue()
        {
            return new IntegerValue(0);
        }
        public override object ToText()
        {
            return "INTEGER";
        }
        public IntegerDataType(DebugSymbol debugSymbol) : base(debugSymbol)
        {
        }
    }

    public partial class DataType
    {
        public bool IsInteger
        {
            get
            {
                return typeof(IntegerDataType).IsAssignableFrom(GetType());
            }
        }
    }
}