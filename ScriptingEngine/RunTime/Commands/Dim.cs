using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class Dim : Command
    {
        public readonly string ObjectName;
        public readonly DataType DataType;
        public override object ToText()
        {
            return Operators.AddObject("DIM " + ObjectName + " ", DataType.ToText());
        }
        public override ScriptTreeNode ToTreeNode()
        {
            return new ScriptTreeNode(this, "DIM", new ScriptTreeNode(this, "Object Name", new ScriptTreeNode(this, ObjectName)), new ScriptTreeNode(this, "Data Type", DataType.ToTreeNode()));
        }
        protected override void DoExecute(Job job, WorkEnvironment workEnvironment)
        {
            if (!job.WorkEnvironment.ObjectExists(ObjectName))
            {
                DataValue targetObject = null;
                var symbol = new ObjectSymbol(ObjectName);
                symbol.Value = DataType.CreateDataValue();
                job.WorkEnvironment.AddSymbol(ObjectName, symbol);
            }
        }
        public Dim(DebugSymbol debugSymbol, string objectName, DataType dataType) : base(debugSymbol)
        {
            ObjectName = objectName;
            DataType = dataType;
        }
    }
}