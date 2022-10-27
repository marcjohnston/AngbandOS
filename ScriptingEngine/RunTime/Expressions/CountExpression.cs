
namespace Big6Search.ScriptingEngine.RunTime
{
    public class Count : Expression
    {

        public readonly string ObjectName;
        public override object ToText()
        {
            return "COUNT(" + ObjectName + ")";
        }
        protected override DataValue DoCompute(Job job)
        {
            ObjectSymbol symbol = (ObjectSymbol)job.WorkEnvironment.GetSymbol(ObjectName);
            var value = symbol.Value;
            if (ReferenceEquals(value.GetType(), typeof(ArrayValue)))
            {
                return new IntegerValue(((ArrayValue)value).Items.Length);
            }
            else
            {
                return new IntegerValue(1);
            }
        }
        public Count(string objectName) : this(null, objectName)
        {
        }
        public Count(DebugSymbol debugSymbol, string objectName) : base(debugSymbol)
        {
            ObjectName = objectName;
        }
    }
}