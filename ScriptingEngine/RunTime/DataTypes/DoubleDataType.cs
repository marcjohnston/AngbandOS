
namespace Big6Search.ScriptingEngine
{
    public class DoubleDataType : DataType
    {

        public override DataValue CreateDataValue()
        {
            return new DoubleValue(0d);
        }
        public override object ToText()
        {
            return "DOUBLE";
        }
        public DoubleDataType(DebugSymbol debugSymbol) : base(debugSymbol)
        {
        }
    }

    public partial class DataType
    {
        public bool IsDouble
        {
            get
            {
                return typeof(DoubleDataType).IsAssignableFrom(GetType());
            }
        }
    }
}