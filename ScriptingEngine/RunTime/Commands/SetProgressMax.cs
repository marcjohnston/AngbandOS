using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class SetProgressMax : Command
    {

        public readonly Expression Current;
        public override object ToText()
        {
            return "SETPROGRESSMAX " + Conversions.ToString(Current.ToText());
        }
        protected override void DoExecute(Job job, WorkEnvironment workEnvironment)
        {
            IntegerValue result = (IntegerValue)Current.Compute<IntegerValue>(job, false);
            job.WorkEnvironment.CurrentProgress.Max = result.Value;
        }
        public SetProgressMax(Expression current) : this(null, current)
        {
        }
        public SetProgressMax(DebugSymbol debugSymbol, Expression current) : base(debugSymbol)
        {
            Current = current;
        }
    }
}