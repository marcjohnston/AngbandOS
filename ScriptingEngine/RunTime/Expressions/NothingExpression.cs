
namespace Big6Search.ScriptingEngine.RunTime
{
    public class NothingExpression : Expression
    {

        protected override DataValue DoCompute(Job job)
        {
            return null;
        }
        public NothingExpression() : this(null)
        {
        }
        public NothingExpression(DebugSymbol debugSymbol) : base(debugSymbol)
        {
        }
    }
}