using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class AndAlsoExpression : Expression
    {

        public readonly Expression Value1;
        public readonly Expression Value2;
        public override object ToText()
        {
            return Conversions.ToString(Value1.ToText()) + " ANDALSO " + Conversions.ToString(Value2.ToText());
        }
        protected override DataValue DoCompute(Job job)
        {
            var result1 = Value1.Compute(job);
            if (result1.IsFalse())
            {
                return new BooleanValue(false);
            }
            else
            {
                var result2 = Value2.Compute(job);
                if (!result2.IsBoolean())
                {
                    throw new RunTimeErrorScriptException("AndAlso operand is not a boolean.");
                }
                else
                {
                    return result2;
                }
            }
        }
        public AndAlsoExpression(Expression value1, Expression value2) : this(null, value1, value2)
        {
        }
        public AndAlsoExpression(DebugSymbol debugSymbol, Expression value1, Expression value2) : base(debugSymbol)
        {
            Value1 = value1;
            Value2 = value2;
        }
    }
}