using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class SetProgressStage : Command
    {

        public readonly Expression Current;
        public override object ToText()
        {
            return "SETPROGRESSTAGE " + Conversions.ToString(Current.ToText());
        }
        protected override void DoExecute(Job job, WorkEnvironment workEnvironment)
        {
            StringValue result = (StringValue)Current.Compute<StringValue>(job, false);
            job.WorkEnvironment.CurrentProgress.Stage = result.Value;
        }
        public SetProgressStage(Expression current) : this(null, current)
        {
        }
        public SetProgressStage(DebugSymbol debugSymbol, Expression current) : base(debugSymbol)
        {
            Current = current;
        }
    }
}