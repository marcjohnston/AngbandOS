
namespace Big6Search.ScriptingEngine
{
    public class CountScriptFactor : FunctionParser
    {

        private ObjectNameFunctionParameterParser _objectName = new ObjectNameFunctionParameterParser();
        protected override RunTime.Expression CreateExpression(DebugSymbol debugSymbol, RunTime.ParameterSymbol[] parameterSymbols)
        {
            RunTime.ObjectNameParameterSymbol objectName = (RunTime.ObjectNameParameterSymbol)parameterSymbols[0];
            return new RunTime.Count(debugSymbol, objectName.ObjectName);
        }
        protected override string FunctionName
        {
            get
            {
                return "COUNT";
            }
        }
        protected override FunctionParameterParser[] ParameterParsers
        {
            get
            {
                return new FunctionParameterParser[] { _objectName };
            }
        }
    }
}