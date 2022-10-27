using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class Set : Command
    {

        public readonly ObjectValue ObjectValue;
        public readonly Expression Value;
        public override object ToText()
        {
            return "SET " + Conversions.ToString(ObjectValue.ToText()) + " = " + Conversions.ToString(Value.ToText());
        }
        protected override void DoExecute(Job job, WorkEnvironment workEnvironment)
        {
            var result = Value.Compute(job);
            ObjectValue.SetValue(job, result);
        }
        public Set(ObjectValue dataValueResolver, Expression value) : this(null, dataValueResolver, value)
        {
        }
        public Set(DebugSymbol debugSymbol, ObjectValue objectValue, Expression value) : base(debugSymbol)
        {
            ObjectValue = objectValue;
            Value = value;
        }
    }
}