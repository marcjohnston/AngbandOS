
namespace Big6Search.ScriptingEngine.RunTime
{
    public class FalseExpression : Expression
    {

        protected override DataValue DoCompute(Job job)
        {
            return new BooleanValue(false);
        }
        public override object ToText()
        {
            return "FALSE";
        }
        public FalseExpression() : this(null)
        {
        }
        public FalseExpression(DebugSymbol debugSymbol) : base(debugSymbol)
        {
        }
    }
}