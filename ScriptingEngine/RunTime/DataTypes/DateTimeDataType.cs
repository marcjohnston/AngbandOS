using System;

namespace Big6Search.ScriptingEngine
{
    public class DateTimeDataType : DataType
    {

        public override DataValue CreateDataValue()
        {
            return new DateTimeValue(new DateTime(1900, 1, 1));
        }
        public override object ToText()
        {
            return "DATETIME";
        }
        public DateTimeDataType(DebugSymbol debugSymbol) : base(debugSymbol)
        {
        }
    }

    public partial class DataType
    {
        public bool IsDateTime
        {
            get
            {
                return typeof(DateTimeDataType).IsAssignableFrom(GetType());
            }
        }
    }
}