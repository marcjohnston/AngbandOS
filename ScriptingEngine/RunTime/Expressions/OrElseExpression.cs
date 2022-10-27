using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class OrElseExpression : Expression
    {

        public readonly Expression Value1;
        public readonly Expression Value2;
        public override object ToText()
        {
            return Conversions.ToString(Value1.ToText()) + " ORELSE " + Conversions.ToString(Value2.ToText());
        }
        protected override DataValue DoCompute(Job job)
        {
            var result1 = Value1.Compute(job);
            if (result1.IsTrue())
            {
                return new BooleanValue(true);
            }
            else
            {
                var result2 = Value2.Compute(job);
                if (!result2.IsBoolean())
                {
                    throw new RunTimeErrorScriptException("OrElse operand is not a boolean.");
                }
                else
                {
                    return result2;
                }
            }
        }
        public OrElseExpression(Expression value1, Expression value2) : this(null, value1, value2)
        {
        }
        public OrElseExpression(DebugSymbol debugSymbol, Expression value1, Expression value2) : base(debugSymbol)
        {
            Value1 = value1;
            Value2 = value2;
        }
    }
}