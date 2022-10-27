
namespace Big6Search.ScriptingEngine.RunTime
{
    public class LiteralExpression : Expression
    {

        public readonly string Value;
        protected override DataValue DoCompute(Job job)
        {
            return new StringValue(Value);
        }
        public override object ToText()
        {
            return Value;
        }
        public LiteralExpression(string value) : this(null, value)
        {
        }
        public LiteralExpression(DebugSymbol debugSymbol, string value) : base(debugSymbol)
        {
            Value = value;
        }
    }
}