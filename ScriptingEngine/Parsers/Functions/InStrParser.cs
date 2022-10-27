using Microsoft.VisualBasic;

namespace Big6Search.ScriptingEngine
{
    public class InStrParser : FunctionParser
    {

        protected override RunTime.Expression CreateExpression(DebugSymbol debugSymbol, RunTime.ParameterSymbol[] parameterSymbols)
        {
            RunTime.ExpressionParameterSymbol stringBeingSearchedExpression = (RunTime.ExpressionParameterSymbol)parameterSymbols[0];
            RunTime.ExpressionParameterSymbol stringSoughtExpression = (RunTime.ExpressionParameterSymbol)parameterSymbols[1];
            if (Information.UBound(parameterSymbols) <= 1)
            {
                return new RunTime.InStrExpression(debugSymbol, stringBeingSearchedExpression.Expression, stringSoughtExpression.Expression);
            }
            else
            {
                RunTime.ExpressionParameterSymbol startExpression = (RunTime.ExpressionParameterSymbol)parameterSymbols[0];
                return new RunTime.InStrExpression(debugSymbol, startExpression.Expression, stringBeingSearchedExpression.Expression, stringSoughtExpression.Expression);
            }
        }
        protected override string FunctionName
        {
            get
            {
                return "InStr";
            }
        }
        protected override FunctionParameterParser[] ParameterParsers
        {
            get
            {
                return new FunctionParameterParser[] { new ExpressionFunctionParameterParser(), new ExpressionFunctionParameterParser(), new ExpressionFunctionParameterParser(true) };
            }
        }
    }
}