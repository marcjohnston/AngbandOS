using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class AddExpression : Expression
    {

        public readonly Expression Value1;
        public readonly Expression Value2;
        public override object ToText()
        {
            return Conversions.ToString(Value1.ToText()) + " + " + Conversions.ToString(Value2.ToText());
        }
        protected override DataValue DoCompute(Job job)
        {
            var result1 = Value1.Compute(job);
            var result2 = Value2.Compute(job);
            return result1.Add(result2);
        }
        public AddExpression(Expression value1, Expression value2) : this(null, value1, value2)
        {
        }
        public AddExpression(DebugSymbol debugSymbol, Expression value1, Expression value2) : base(debugSymbol)
        {
            Value1 = value1;
            Value2 = value2;
        }
    }
}