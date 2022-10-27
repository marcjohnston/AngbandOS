
namespace Big6Search.ScriptingEngine
{

    public class NothingFunctionParser : FunctionParser
    {

        protected override RunTime.Expression CreateExpression(DebugSymbol debugSymbol, RunTime.ParameterSymbol[] parameterSymbols)
        {
            return new RunTime.NothingExpression(debugSymbol);
        }
        protected override string FunctionName
        {
            get
            {
                return "NOTHING";
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