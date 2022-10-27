using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class IsEqualToExpression : BinaryBooleanComparisonExpression
    {

        protected override DataValue DoCompute(Job job)
        {
            var result1 = Value1.Compute(job);
            var result2 = Value2.Compute(job);
            return result1.IsEqualTo(result2);
        }
        public override object ToText()
        {
            return Conversions.ToString(Value1.ToText()) + " = " + Conversions.ToString(Value2.ToText());
        }
        public IsEqualToExpression(Expression simpleExpression1, Expression simpleExpression2) : this(null, simpleExpression1, simpleExpression2)
        {
        }
        public IsEqualToExpression(DebugSymbol debugSymbol, Expression simpleExpression1, Expression simpleExpression2) : base(debugSymbol, simpleExpression1, simpleExpression2)
        {
        }
    }
}