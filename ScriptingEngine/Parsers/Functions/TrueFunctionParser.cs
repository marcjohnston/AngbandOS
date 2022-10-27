
namespace Big6Search.ScriptingEngine
{

    public class TrueFunctionParser : FunctionParser
    {

        protected override RunTime.Expression CreateExpression(DebugSymbol debugSymbol, RunTime.ParameterSymbol[] parameterSymbols)
        {
            return new RunTime.TrueExpression(debugSymbol);
        }
        protected override string FunctionName
        {
            get
            {
                return "TRUE";
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