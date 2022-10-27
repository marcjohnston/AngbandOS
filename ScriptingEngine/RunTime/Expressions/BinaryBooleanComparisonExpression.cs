
namespace Big6Search.ScriptingEngine.RunTime
{
    public abstract class BinaryBooleanComparisonExpression : Expression
    {

        public readonly Expression Value1;
        public readonly Expression Value2;
        public BinaryBooleanComparisonExpression(Expression value1, Expression value2) : this(null, value1, value2)
        {
        }
        public BinaryBooleanComparisonExpression(DebugSymbol debugSymbol, Expression value1, Expression value2) : base(debugSymbol)
        {
            Value1 = value1;
            Value2 = value2;
        }
    }
}