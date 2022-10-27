
namespace Big6Search.ScriptingEngine.RunTime
{
    public class Stop : Command
    {

        protected override void DoExecute(Job job, WorkEnvironment workEnvironment)
        {
            job.Stop();
        }
        public override object ToText()
        {
            return "STOP";
        }
        public Stop() : this(null)
        {
        }
        public Stop(DebugSymbol debugSymbol) : base(debugSymbol)
        {
        }
    }
}