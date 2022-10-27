
namespace Big6Search.ScriptingEngine.RunTime
{
    public class IntegerExpression : Expression
    {

        public readonly int Value;
        public override object ToText()
        {
            return Value.ToString();
        }
        protected override DataValue DoCompute(Job job)
        {
            return new IntegerValue(Value);
        }
        public IntegerExpression(int value) : this(null, value)
        {
        }
        public IntegerExpression(DebugSymbol debugSymbol, int value) : base(debugSymbol)
        {
            Value = value;
        }
    }
}