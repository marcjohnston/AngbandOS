
namespace Big6Search.ScriptingEngine.RunTime
{
    public class Comment : Command
    {

        public readonly string CommentField;
        public override object ToText()
        {
            return "' " + CommentField;
        }
        public override ScriptTreeNode ToTreeNode()
        {
            return new ScriptTreeNode(this, "' " + CommentField);
        }
        protected override void DoExecute(Job job, WorkEnvironment workEnvironment)
        {
        }
        public Comment(string comment) : this(null, comment)
        {
        }
        public Comment(DebugSymbol debugSymbol, string comment) : base(debugSymbol)
        {
            CommentField = comment;
        }
    }
}