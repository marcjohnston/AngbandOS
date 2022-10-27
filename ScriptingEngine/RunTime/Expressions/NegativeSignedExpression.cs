
namespace Big6Search.ScriptingEngine.RunTime
{
    public class NegativeSignedExpression : Expression
    {

        public readonly Expression Expression;
        protected override DataValue DoCompute(Job job)
        {
            var value = Expression.Compute(job);
            if (value.IsDouble())
            {
                return new DoubleValue(-((DoubleValue)value).Value);
            }
            else if (value.IsInteger())
            {
                return new IntegerValue(-((IntegerValue)value).Value);
            }
            else
            {
                throw new RunTimeErrorScriptException("Invalid data type.  Numeric expression expected.");
            }
        }
        public NegativeSignedExpression(Expression value) : this(null, value)
        {
        }
        public NegativeSignedExpression(DebugSymbol debugSymbol, Expression expression) : base(debugSymbol)
        {
            Expression = expression;
        }
    }
}