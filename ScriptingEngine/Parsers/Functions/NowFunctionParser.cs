
namespace Big6Search.ScriptingEngine
{

    public class NowFunctionParser : FunctionParser
    {

        protected override RunTime.Expression CreateExpression(DebugSymbol debugSymbol, RunTime.ParameterSymbol[] parameterSymbols)
        {
            return new RunTime.NowExpression(debugSymbol);
        }
        protected override string FunctionName
        {
            get
            {
                return "NOW";
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