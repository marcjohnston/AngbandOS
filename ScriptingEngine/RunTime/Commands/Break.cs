
namespace Big6Search.ScriptingEngine.RunTime
{
    public class Break : Command
    {

        protected override void DoExecute(Job job, WorkEnvironment workEnvironment)
        {
            job.Pause();
        }
        public override object ToText()
        {
            return "BREAK";
        }
        public override ScriptTreeNode ToTreeNode()
        {
            return new ScriptTreeNode(this, "BREAK");
        }
        public Break() : this(null)
        {
        }
        public Break(DebugSymbol debugSymbol) : base(debugSymbol)
        {
        }
    }
}