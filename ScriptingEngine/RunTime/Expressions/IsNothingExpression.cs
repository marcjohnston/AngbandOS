using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class IsNothingExpression : Expression
    {

        public readonly Expression Expression;
        public override object ToText()
        {
            return "IsNothing(" + Conversions.ToString(Expression.ToText()) + ")";
        }
        protected override DataValue DoCompute(Job job)
        {
            var value = Expression.Compute(job);
            return new BooleanValue(value == null);
        }
        public IsNothingExpression(Expression expression) : this(null, expression)
        {
        }
        public IsNothingExpression(DebugSymbol debugSymbol, Expression expression) : base(debugSymbol)
        {
            Expression = expression;
        }
    }
}