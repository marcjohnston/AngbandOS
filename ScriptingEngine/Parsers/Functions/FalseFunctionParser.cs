
namespace Big6Search.ScriptingEngine
{

    public class FalseFunctionParser : FunctionParser
    {

        protected override RunTime.Expression CreateExpression(DebugSymbol debugSymbol, RunTime.ParameterSymbol[] parameterSymbols)
        {
            return new RunTime.FalseExpression(debugSymbol);
        }
        protected override string FunctionName
        {
            get
            {
                return "FALSE";
            }
        }
        protected override FunctionParameterParser[] ParameterParsers
        {
            get
            {
                return null;
            }
        }
    }
}