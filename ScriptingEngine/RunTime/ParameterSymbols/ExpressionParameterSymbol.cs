
namespace Big6Search.ScriptingEngine.RunTime
{
    public class ExpressionParameterSymbol : ParameterSymbol
    {

        public readonly Expression Expression;
        public ExpressionParameterSymbol(Expression expression) : this(null, expression)
        {
        }
        public ExpressionParameterSymbol(DebugSymbol debugSymbol, Expression expression) : base(debugSymbol)
        {
            Expression = expression;
        }
    }
}