
namespace Big6Search.ScriptingEngine.RunTime
{
    public class TrueExpression : Expression
    {

        protected override DataValue DoCompute(Job job)
        {
            return new BooleanValue(true);
        }
        public override object ToText()
        {
            return "TRUE";
        }
        public TrueExpression() : this(null)
        {
        }
        public TrueExpression(DebugSymbol debugSymbol) : base(debugSymbol)
        {
        }
    }
}