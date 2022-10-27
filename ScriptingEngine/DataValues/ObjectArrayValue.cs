using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine
{
    public class ObjectArrayValue : ObjectValue
    {

        public readonly RunTime.Expression Index;
        public override DataValue GetValue(RunTime.Job job)
        {
            var dataValue = base.GetValue(job);
            if (!dataValue.IsArray())
            {
                throw new RunTimeErrorScriptException(ObjectName + " is not an array.");
            }
            IntegerValue indexDataValue = (IntegerValue)Index.Compute<IntegerValue>(job, false);
            {
                var withBlock = (ArrayValue)dataValue;
                return withBlock.Items[indexDataValue.Value];
            }
        }
        public override ScriptTreeNode ToTreeNode()
        {
            return new ScriptTreeNode(this, ObjectName + "[]", Index.ToTreeNode());
        }
        public override object ToText()
        {
            return Operators.AddObject(Operators.AddObject(Conversions.ToString(base.ToText()) + "[", Index.ToText()), "]");
        }
        public override void SetValue(RunTime.Job job, DataValue value)
        {
            base.SetValue(job, value);
        }
        public ObjectArrayValue(string objectName, RunTime.Expression index) : this(null, objectName, index)
        {
        }
        public ObjectArrayValue(DebugSymbol debugSymbol, string objectName, RunTime.Expression index) : base(debugSymbol, objectName)
        {
            Index = index;
        }

    }
}