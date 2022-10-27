using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine
{
    public class ArrayDataType : DataType
    {

        public readonly int Length;
        public readonly DataType DataType;
        public override DataValue CreateDataValue()
        {
            DataValue[] initialValue;
            initialValue = new DataValue[Length + 1];
            for (int i = 0, loopTo = Length - 1; i <= loopTo; i++)
                initialValue[i] = DataType.CreateDataValue();
            return new ArrayValue(initialValue);
        }
        public override object ToText()
        {
            return Conversions.ToString(DataType.ToText()) + "[" + Length.ToString() + "]";
        }
        public ArrayDataType(DebugSymbol debugSymbol, int length, DataType dataType) : base(debugSymbol)
        {
            Length = length;
            DataType = dataType;
        }
    }
}