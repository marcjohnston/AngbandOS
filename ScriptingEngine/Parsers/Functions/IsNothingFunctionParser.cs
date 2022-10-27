
namespace Big6Search.ScriptingEngine
{
    public class IsNothingFunctionParser : FunctionParser
    {

        private ExpressionFunctionParameterParser _expression = new ExpressionFunctionParameterParser();
        protected override RunTime.Expression CreateExpression(DebugSymbol debugSymbol, RunTime.ParameterSymbol[] parameterSymbols)
        {
            RunTime.ExpressionParameterSymbol expression = (RunTime.ExpressionParameterSymbol)parameterSymbols[0];
            return new RunTime.IsNothingExpression(debugSymbol, expression.Expression);
        }
        protected override string FunctionName
        {
            get
            {
                return "ISNOTHING";
            }
        }
        protected override FunctionParameterParser[] ParameterParsers
        {
            get
            {
                return new FunctionParameterParser[] { _expression };
            }
        }
    }
}