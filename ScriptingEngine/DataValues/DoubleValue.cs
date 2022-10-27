using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine
{
    public class DoubleValue : DataValue
    {

        public new double Value
        {
            get
            {
                return Conversions.ToDouble(base.Value);
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
        public override DataValue Subtract(DataValue value)
        {
            if (value.IsInteger())
            {
                return Subtract(this, (IntegerValue)value);
            }
            else if (value.IsDouble())
            {
                return Subtract(this, (DoubleValue)value);
            }
            else
            {
                return base.Subtract(value);
            }
        }
        public override DataValue Multiply(DataValue value)
        {
            if (value.IsInteger())
            {
                return Multiply(this, (IntegerValue)value);
            }
            else if (value.IsDouble())
            {
                return Multiply(this, (DoubleValue)value);
            }
            else
            {
                return base.Multiply(value);
            }
        }
        public override DataValue Divide(DataValue value)
        {
            if (value.IsInteger())
            {
                return Divide(this, (IntegerValue)value);
            }
            else if (value.IsDouble())
            {
                return Divide(this, (DoubleValue)value);
            }
            else
            {
                return base.Divide(value);
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
                return base.IsEqualTo(value);
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
                return base.IsNotEqualTo(value);
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
                return base.IsLessThan(value);
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
                return base.IsLessThanOrEqualTo(value);
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
                return base.IsGreaterThan(value);
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
                return base.IsGreaterThanOrEqualTo(value);
            }
        }
        public static DoubleValue Add(DoubleValue value1, IntegerValue value2)
        {
            return new DoubleValue(value1.Value + value2.Value);
        }
        public static DoubleValue Add(DoubleValue value1, DoubleValue value2)
        {
            return new DoubleValue(value1.Value + value2.Value);
        }
        public static StringValue Add(DoubleValue value1, StringValue value2)
        {
            return new StringValue(value1.Value.ToString() + value2.Value);
        }
        public static DoubleValue Subtract(DoubleValue value1, IntegerValue value2)
        {
            return new DoubleValue(value1.Value - value2.Value);
        }
        public static DoubleValue Subtract(DoubleValue value1, DoubleValue value2)
        {
            return new DoubleValue(value1.Value - value2.Value);
        }
        public static DoubleValue Multiply(DoubleValue value1, IntegerValue value2)
        {
            return new DoubleValue(value1.Value * value2.Value);
        }
        public static DoubleValue Multiply(DoubleValue value1, DoubleValue value2)
        {
            return new DoubleValue(value1.Value * value2.Value);
        }
        public static DoubleValue Divide(DoubleValue value1, IntegerValue value2)
        {
            return new DoubleValue(value1.Value / value2.Value);
        }
        public static DoubleValue Divide(DoubleValue value1, DoubleValue value2)
        {
            return new DoubleValue(value1.Value / value2.Value);
        }
        public static BooleanValue IsEqualTo(DoubleValue value1, IntegerValue value2)
        {
            return new BooleanValue(value1.Value == value2.Value);
        }
        public static BooleanValue IsEqualTo(DoubleValue value1, DoubleValue value2)
        {
            return new BooleanValue(value1.Value == value2.Value);
        }
        public static BooleanValue IsEqualTo(DoubleValue value1, StringValue value2)
        {
            return new BooleanValue((value1.Value.ToString() ?? "") == (value2.Value ?? ""));
        }
        public static BooleanValue IsNotEqualTo(DoubleValue value1, IntegerValue value2)
        {
            return new BooleanValue(value1.Value != value2.Value);
        }
        public static BooleanValue IsNotEqualTo(DoubleValue value1, DoubleValue value2)
        {
            return new BooleanValue(value1.Value != value2.Value);
        }
        public static BooleanValue IsNotEqualTo(DoubleValue value1, StringValue value2)
        {
            return new BooleanValue((value1.Value.ToString() ?? "") != (value2.Value ?? ""));
        }
        public static BooleanValue IsLessThan(DoubleValue value1, IntegerValue value2)
        {
            return new BooleanValue(value1.Value < value2.Value);
        }
        public static BooleanValue IsLessThan(DoubleValue value1, DoubleValue value2)
        {
            return new BooleanValue(value1.Value < value2.Value);
        }
        public static BooleanValue IsLessThan(DoubleValue value1, StringValue value2)
        {
            return new BooleanValue(Operators.CompareString(value1.Value.ToString(), value2.Value, false) < 0);
        }
        public static BooleanValue IsLessThanOrEqualTo(DoubleValue value1, IntegerValue value2)
        {
            return new BooleanValue(value1.Value <= value2.Value);
        }
        public static BooleanValue IsLessThanOrEqualTo(DoubleValue value1, DoubleValue value2)
        {
            return new BooleanValue(value1.Value <= value2.Value);
        }
        public static BooleanValue IsLessThanOrEqualTo(DoubleValue value1, StringValue value2)
        {
            return new BooleanValue(Operators.CompareString(value1.Value.ToString(), value2.Value, false) <= 0);
        }
        public static BooleanValue IsGreaterThan(DoubleValue value1, IntegerValue value2)
        {
            return new BooleanValue(value1.Value > value2.Value);
        }
        public static BooleanValue IsGreaterThan(DoubleValue value1, DoubleValue value2)
        {
            return new BooleanValue(value1.Value > value2.Value);
        }
        public static BooleanValue IsGreaterThan(DoubleValue value1, StringValue value2)
        {
            return new BooleanValue(Operators.CompareString(value1.Value.ToString(), value2.Value, false) > 0);
        }
        public static BooleanValue IsGreaterThanOrEqualTo(DoubleValue value1, IntegerValue value2)
        {
            return new BooleanValue(value1.Value >= value2.Value);
        }
        public static BooleanValue IsGreaterThanOrEqualTo(DoubleValue value1, DoubleValue value2)
        {
            return new BooleanValue(value1.Value >= value2.Value);
        }
        public static BooleanValue IsGreaterThanOrEqualTo(DoubleValue value1, StringValue value2)
        {
            return new BooleanValue(Operators.CompareString(value1.Value.ToString(), value2.Value, false) >= 0);
        }
        public override string ToString()
        {
            return Value.ToString();
        }
        public DoubleValue(double value)
        {
            Value = value;
        }
    }
}