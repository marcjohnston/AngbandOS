using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine
{
    public class StringValue : DataValue
    {
        public new string Value
        {
            get
            {
                return Conversions.ToString(base.Value);
            }
            set
            {
                base.Value = value;
            }
        }
        public override DataValue Add(DataValue value)
        {
            if (value.IsInteger())
            {
                return Add(this, (IntegerValue)value);
            }
            else if (value.IsDouble())
            {
                return Add(this, (DoubleValue)value);
            }
            else if (value.IsString())
            {
                return Add(this, (StringValue)value);
            }
            else
            {
                return base.Add(value);
            }
        }
        public override DataValue IsEqualTo(DataValue value)
        {
            if (value.IsInteger())
            {
                return IsEqualTo(this, (IntegerValue)value);
            }
            else if (value.IsDouble())
            {
                return IsEqualTo(this, (DoubleValue)value);
            }
            else if (value.IsString())
            {
                return IsEqualTo(this, (StringValue)value);
            }
            else
            {
                return base.Add(value);
            }
        }
        public override DataValue IsNotEqualTo(DataValue value)
        {
            if (value.IsInteger())
            {
                return IsNotEqualTo(this, (IntegerValue)value);
            }
            else if (value.IsDouble())
            {
                return IsNotEqualTo(this, (DoubleValue)value);
            }
            else if (value.IsString())
            {
                return IsNotEqualTo(this, (StringValue)value);
            }
            else
            {
                return base.Add(value);
            }
        }
        public override DataValue IsLessThan(DataValue value)
        {
            if (value.IsInteger())
            {
                return IsLessThan(this, (IntegerValue)value);
            }
            else if (value.IsDouble())
            {
                return IsLessThan(this, (DoubleValue)value);
            }
            else if (value.IsString())
            {
                return IsLessThan(this, (StringValue)value);
            }
            else
            {
                return base.Add(value);
            }
        }
        public override DataValue IsLessThanOrEqualTo(DataValue value)
        {
            if (value.IsInteger())
            {
                return IsLessThanOrEqualTo(this, (IntegerValue)value);
            }
            else if (value.IsDouble())
            {
                return IsLessThanOrEqualTo(this, (DoubleValue)value);
            }
            else if (value.IsString())
            {
                return IsLessThanOrEqualTo(this, (StringValue)value);
            }
            else
            {
                return base.Add(value);
            }
        }
        public override DataValue IsGreaterThan(DataValue value)
        {
            if (value.IsInteger())
            {
                return IsGreaterThan(this, (IntegerValue)value);
            }
            else if (value.IsDouble())
            {
                return IsGreaterThan(this, (DoubleValue)value);
            }
            else if (value.IsString())
            {
                return IsGreaterThan(this, (StringValue)value);
            }
            else
            {
                return base.Add(value);
            }
        }
        public override DataValue IsGreaterThanOrEqualTo(DataValue value)
        {
            if (value.IsInteger())
            {
                return IsGreaterThanOrEqualTo(this, (IntegerValue)value);
            }
            else if (value.IsDouble())
            {
                return IsGreaterThanOrEqualTo(this, (DoubleValue)value);
            }
            else if (value.IsString())
            {
                return IsGreaterThanOrEqualTo(this, (StringValue)value);
            }
            else
            {
                return base.Add(value);
            }
        }
        public static StringValue Add(StringValue value1, IntegerValue value2)
        {
            return new StringValue(value1.Value + value2.Value.ToString());
        }
        public static StringValue Add(StringValue value1, DoubleValue value2)
        {
            return new StringValue(value1.Value + value2.Value.ToString());
        }
        public static StringValue Add(StringValue value1, StringValue value2)
        {
            return new StringValue(value1.Value + value2.Value);
        }
        public static BooleanValue IsEqualTo(StringValue value1, IntegerValue value2)
        {
            return new BooleanValue((value1.Value ?? "") == (value2.Value.ToString() ?? ""));
        }
        public static BooleanValue IsEqualTo(StringValue value1, DoubleValue value2)
        {
            return new BooleanValue((value1.Value ?? "") == (value2.Value.ToString() ?? ""));
        }
        public static BooleanValue IsEqualTo(StringValue value1, StringValue value2)
        {
            return new BooleanValue((value1.Value ?? "") == (value2.Value ?? ""));
        }
        public static BooleanValue IsNotEqualTo(StringValue value1, IntegerValue value2)
        {
            return new BooleanValue((value1.Value ?? "") != (value2.Value.ToString() ?? ""));
        }
        public static BooleanValue IsNotEqualTo(StringValue value1, DoubleValue value2)
        {
            return new BooleanValue((value1.Value ?? "") != (value2.Value.ToString() ?? ""));
        }
        public static BooleanValue IsNotEqualTo(StringValue value1, StringValue value2)
        {
            return new BooleanValue((value1.Value ?? "") != (value2.Value ?? ""));
        }
        public static BooleanValue IsLessThan(StringValue value1, IntegerValue value2)
        {
            return new BooleanValue(Operators.CompareString(value1.Value, value2.Value.ToString(), false) < 0);
        }
        public static BooleanValue IsLessThan(StringValue value1, DoubleValue value2)
        {
            return new BooleanValue(Operators.CompareString(value1.Value, value2.Value.ToString(), false) < 0);
        }
        public static BooleanValue IsLessThan(StringValue value1, StringValue value2)
        {
            return new BooleanValue(Operators.CompareString(value1.Value, value2.Value, false) < 0);
        }
        public static BooleanValue IsLessThanOrEqualTo(StringValue value1, IntegerValue value2)
        {
            return new BooleanValue(Operators.CompareString(value1.Value, value2.Value.ToString(), false) <= 0);
        }
        public static BooleanValue IsLessThanOrEqualTo(StringValue value1, DoubleValue value2)
        {
            return new BooleanValue(Operators.CompareString(value1.Value, value2.Value.ToString(), false) <= 0);
        }
        public static BooleanValue IsLessThanOrEqualTo(StringValue value1, StringValue value2)
        {
            return new BooleanValue(Operators.CompareString(value1.Value, value2.Value, false) <= 0);
        }
        public static BooleanValue IsGreaterThan(StringValue value1, IntegerValue value2)
        {
            return new BooleanValue(Operators.CompareString(value1.Value, value2.Value.ToString(), false) > 0);
        }
        public static BooleanValue IsGreaterThan(StringValue value1, DoubleValue value2)
        {
            return new BooleanValue(Operators.CompareString(value1.Value, value2.Value.ToString(), false) > 0);
        }
        public static BooleanValue IsGreaterThan(StringValue value1, StringValue value2)
        {
            return new BooleanValue(Operators.CompareString(value1.Value, value2.Value, false) > 0);
        }
        public static BooleanValue IsGreaterThanOrEqualTo(StringValue value1, IntegerValue value2)
        {
            return new BooleanValue(Operators.CompareString(value1.Value, value2.Value.ToString(), false) >= 0);
        }
        public static BooleanValue IsGreaterThanOrEqualTo(StringValue value1, DoubleValue value2)
        {
            return new BooleanValue(Operators.CompareString(value1.Value, value2.Value.ToString(), false) >= 0);
        }
        public static BooleanValue IsGreaterThanOrEqualTo(StringValue value1, StringValue value2)
        {
            return new BooleanValue(Operators.CompareString(value1.Value, value2.Value, false) >= 0);
        }
        public override string ToString()
        {
            return Value;
        }
        public StringValue(string value)
        {
            Value = value;
        }
    }
}