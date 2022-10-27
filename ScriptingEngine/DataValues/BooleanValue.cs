using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine
{
    public class BooleanValue : DataValue
    {

        public new bool Value
        {
            get
            {
                return Conversions.ToBoolean(base.Value);
            }
            set
            {
                base.Value = value;
            }
        }
        public override DataValue Or(DataValue value)
        {
            return Or(this, (BooleanValue)value);
        }
        public override DataValue And(DataValue value)
        {
            return And(this, (BooleanValue)value);
        }
        public override DataValue IsEqualTo(DataValue value)
        {
            if (value.IsBoolean())
            {
                return IsEqualTo(this, (BooleanValue)value);
            }
            else
            {
                return base.IsEqualTo(value);
            }
        }
        public override DataValue IsNotEqualTo(DataValue value)
        {
            if (value.IsBoolean())
            {
                return IsNotEqualTo(this, (BooleanValue)value);
            }
            else
            {
                return base.IsEqualTo(value);
            }
        }
        public static BooleanValue IsEqualTo(BooleanValue value1, BooleanValue value2)
        {
            return new BooleanValue(value1.Value == value2.Value);
        }
        public static BooleanValue IsNotEqualTo(BooleanValue value1, BooleanValue value2)
        {
            return new BooleanValue(value1.Value != value2.Value);
        }
        public static BooleanValue Or(BooleanValue value1, BooleanValue value2)
        {
            return new BooleanValue(value1.Value | value2.Value);
        }
        public static BooleanValue And(BooleanValue value1, BooleanValue value2)
        {
            return new BooleanValue(value1.Value & value2.Value);
        }
        public override string ToString()
        {
            return Value.ToString();
        }
        public BooleanValue(bool value)
        {
            Value = value;
        }
    }
}