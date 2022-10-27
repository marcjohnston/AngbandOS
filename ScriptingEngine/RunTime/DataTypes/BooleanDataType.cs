
namespace Big6Search.ScriptingEngine
{
    public class BooleanDataType : DataType
    {

        public override DataValue CreateDataValue()
        {
            return new BooleanValue(false);
        }
        public override object ToText()
        {
            return "BOOLEAN";
        }
        public BooleanDataType(DebugSymbol debugSymbol) : base(debugSymbol)
        {
        }
    }

    public partial class DataType
    {
        public bool IsBoolean
        {
            get
            {
                return typeof(BooleanDataType).IsAssignableFrom(GetType());
            }
        }
    }
}