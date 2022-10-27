using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class Wait : Command
    {

        public readonly Expression Milliseconds;
        public override object ToText()
        {
            return "WAIT " + Conversions.ToString(Milliseconds.ToText());
        }
        protected override void DoExecute(Job job, WorkEnvironment workEnvironment)
        {
            IntegerValue result = (IntegerValue)Milliseconds.Compute<IntegerValue>(job, false);
            System.Threading.Thread.Sleep(result.Value);
        }
        public Wait(Expression milliseconds) : this(null, milliseconds)
        {
        }
        public Wait(DebugSymbol debugSymbol, Expression milliseconds) : base(debugSymbol)
        {
            Milliseconds = milliseconds;
        }
    }
}