
namespace Big6Search.ScriptingEngine.RunTime
{
    public class DoubleExpression : Expression
    {

        public readonly double Value;
        public override object ToText()
        {
            return Value.ToString();
        }
        protected override DataValue DoCompute(Job job)
        {
            return new DoubleValue(Value);
        }
        public DoubleExpression(double value) : this(null, value)
        {
        }
        public DoubleExpression(DebugSymbol debugSymbol, double value) : base(debugSymbol)
        {
            Value = value;
        }
    }
}