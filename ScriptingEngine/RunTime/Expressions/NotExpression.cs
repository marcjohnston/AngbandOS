
namespace Big6Search.ScriptingEngine.RunTime
{
    public class NotExpression : Expression
    {

        public readonly Expression Expression;
        protected override DataValue DoCompute(Job job)
        {
            var value = Expression.Compute(job);
            if (!value.IsBoolean())
            {
                throw new RunTimeErrorScriptException("Invalid data type for NOT operator.");
            }
            return new BooleanValue(!((BooleanValue)value).Value);
        }
        public NotExpression(Expression expression) : this(null, expression)
        {
        }
        public NotExpression(DebugSymbol debugSymbol, Expression expression) : base(debugSymbol)
        {
            Expression = expression;
        }
    }
}