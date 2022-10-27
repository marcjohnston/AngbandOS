using Microsoft.VisualBasic;

namespace Big6Search.ScriptingEngine
{
    public class TokenFunctionParser : FunctionParser
    {

        protected override RunTime.Expression CreateExpression(DebugSymbol debugSymbol, RunTime.ParameterSymbol[] parameterSymbols)
        {
            RunTime.ExpressionParameterSymbol textExpression = (RunTime.ExpressionParameterSymbol)parameterSymbols[0];
            RunTime.ExpressionParameterSymbol delimiterExpression = (RunTime.ExpressionParameterSymbol)parameterSymbols[1];
            RunTime.ExpressionParameterSymbol fieldIndexExpression = (RunTime.ExpressionParameterSymbol)parameterSymbols[2];
            if (Information.UBound(parameterSymbols) <= 2)
            {
                return new RunTime.Token(debugSymbol, textExpression.Expression, delimiterExpression.Expression, fieldIndexExpression.Expression);
            }
            else
            {
                RunTime.ExpressionParameterSymbol returnRemainingFieldExpression = (RunTime.ExpressionParameterSymbol)parameterSymbols[3];
                return new RunTime.Token(debugSymbol, textExpression.Expression, delimiterExpression.Expression, fieldIndexExpression.Expression, returnRemainingFieldExpression.Expression);
            }
        }
        protected override string FunctionName
        {
            get
            {
                return "Token";
            }
        }
        protected override FunctionParameterParser[] ParameterParsers
        {
            get
            {
                return new FunctionParameterParser[] { new ExpressionFunctionParameterParser(), new ExpressionFunctionParameterParser(), new ExpressionFunctionParameterParser(), new ExpressionFunctionParameterParser(true) };
            }
        }
    }
}