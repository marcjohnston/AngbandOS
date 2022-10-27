
namespace Big6Search.ScriptingEngine.RunTime
{
    public class PositiveSignedExpression : Expression
    {

        public readonly Expression Expression;
        protected override DataValue DoCompute(Job job)
        {
            var value = Expression.Compute(job);
            if (value.IsNumeric())
            {
                return value;
            }
            else
            {
                throw new RunTimeErrorScriptException("Invalid data type.  Numeric expression expected.");
            }
        }
        public PositiveSignedExpression(Expression value) : this(null, value)
        {
        }
        public PositiveSignedExpression(DebugSymbol debugSymbol, Expression expression) : base(debugSymbol)
        {
            Expression = expression;
        }
    }
}