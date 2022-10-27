using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine
{
    public class DateTimeValue : DataValue
    {

        public new DateTime Value
        {
            get
            {
                return Conversions.ToDate(base.Value);
            }
            set
            {
                base.Value = value;
            }
        }
        public override DataValue IsEqualTo(DataValue value)
        {
            if (value.IsDateTime())
            {
                return IsEqualTo(this, (DateTimeValue)value);
            }
            else
            {
                return base.IsEqualTo(value);
            }
        }
        public override DataValue IsNotEqualTo(DataValue value)
        {
            if (value.IsDateTime())
            {
                return IsNotEqualTo(this, (DateTimeValue)value);
            }
            else
            {
                return base.IsEqualTo(value);
            }
        }
        public override DataValue IsLessThan(DataValue value)
        {
            if (value.IsDateTime())
            {
                return IsLessThan(this, (DateTimeValue)value);
            }
            else
            {
                return base.IsLessThan(value);
            }
        }
        public override DataValue IsLessThanOrEqualTo(DataValue value)
        {
            if (value.IsDateTime())
            {
                return IsLessThanOrEqualTo(this, (DateTimeValue)value);
            }
            else
            {
                return base.IsLessThanOrEqualTo(value);
            }
        }
        public override DataValue IsGreaterThan(DataValue value)
        {
            if (value.IsDateTime())
            {
                return IsGreaterThan(this, (DateTimeValue)value);
            }
            else
            {
                return base.IsGreaterThan(value);
            }
        }
        public override DataValue IsGreaterThanOrEqualTo(DataValue value)
        {
            if (value.IsDateTime())
            {
                return IsGreaterThanOrEqualTo(this, (DateTimeValue)value);
            }
            else
            {
                return base.IsGreaterThanOrEqualTo(value);
            }
        }
        public static BooleanValue IsEqualTo(DateTimeValue value1, DateTimeValue value2)
        {
            return new BooleanValue(value1.Value == value2.Value);
        }
        public static BooleanValue IsNotEqualTo(DateTimeValue value1, DateTimeValue value2)
        {
            return new BooleanValue(value1.Value != value2.Value);
        }
        public static BooleanValue IsLessThan(DateTimeValue value1, DateTimeValue value2)
        {
            return new BooleanValue(value1.Value < value2.Value);
        }
        public static BooleanValue IsLessThanOrEqualTo(DateTimeValue value1, DateTimeValue value2)
        {
            return new BooleanValue(value1.Value <= value2.Value);
        }
        public static BooleanValue IsGreaterThan(DateTimeValue value1, DateTimeValue value2)
        {
            return new BooleanValue(value1.Value > value2.Value);
        }
        public static BooleanValue IsGreaterThanOrEqualTo(DateTimeValue value1, DateTimeValue value2)
        {
            return new BooleanValue(value1.Value >= value2.Value);
        }
        public override string ToString()
        {
            return Value.ToString();
        }
        public DateTimeValue(DateTime value)
        {
            Value = value;
        }
    }
}