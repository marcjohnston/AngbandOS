using System;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class NowExpression : Expression
    {

        protected override DataValue DoCompute(Job job)
        {
            return new DateTimeValue(DateTime.Now);
        }
        public NowExpression() : this(null)
        {
        }
        public NowExpression(DebugSymbol debugSymbol) : base(debugSymbol)
        {
        }
    }
}