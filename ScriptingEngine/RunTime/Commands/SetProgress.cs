using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class SetProgress : Command
    {

        public readonly Expression Current;
        public override object ToText()
        {
            return "SETPROGRESS " + Conversions.ToString(Current.ToText());
        }
        protected override void DoExecute(Job job, WorkEnvironment workEnvironment)
        {
            var result = Current.Compute(job);
            if (!result.IsInteger())
            {
                throw new RunTimeErrorScriptException("Invalid parameter.");
            }
            job.WorkEnvironment.CurrentProgress.Current = ((IntegerValue)result).Value;
        }
        public SetProgress(Expression current) : this(null, current)
        {
        }
        public SetProgress(DebugSymbol debugSymbol, Expression current) : base(debugSymbol)
        {
            Current = current;
        }
    }
}