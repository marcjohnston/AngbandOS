
namespace Big6Search.ScriptingEngine
{
    public class StringDataType : DataType
    {

        public override DataValue CreateDataValue()
        {
            return new StringValue(null);
        }
        public override object ToText()
        {
            return "STRING";
        }
        public StringDataType(DebugSymbol debugSymbol) : base(debugSymbol)
        {
        }
    }

    public partial class DataType
    {
        public bool IsString
        {
            get
            {
                return typeof(StringDataType).IsAssignableFrom(GetType());
            }
        }
    }
}