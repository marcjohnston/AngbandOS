using System.Collections.Generic;
using byMarc.Net2.Library.LanguageParsing;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine
{

    public static class SyntaxParser
    {

        #region Private, Protected and Friends
        private static RunTime.Expression ParseExpressionLogicalTerm(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            var value = ParseExpressionMagnitideComparator(parser, scriptEngine, workEnvironment);

            bool done = false;
            do
            {
                switch (Strings.UCase(parser.PeekNextToken().MatchedText) ?? "")
                {
                    case "AND":
                        {
                            parser.GetNextToken();
                            int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                            var magnitudeComparator = ParseExpressionMagnitideComparator(parser, scriptEngine, workEnvironment);
                            value = new RunTime.AndExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, magnitudeComparator);
                            break;
                        }
                    case "ANDALSO":
                        {
                            parser.GetNextToken();
                            int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                            var magnitudeComparator = ParseExpressionMagnitideComparator(parser, scriptEngine, workEnvironment);
                            value = new RunTime.AndAlsoExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, magnitudeComparator);
                            break;
                        }

                    default:
                        {
                            done = true;
                            break;
                        }
                }
            }
            while (!done);
            return value;
        }
        private static RunTime.Expression ParseExpressionMagnitideComparator(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            var value = ParseExpressionUrnaryOperation(parser, scriptEngine, workEnvironment);

            bool done = false;
            do
            {
                switch (Strings.UCase(parser.PeekNextToken().MatchedText) ?? "")
                {
                    case "=":
                        {
                            parser.GetNextToken();
                            int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                            var urnaryOperation = ParseExpressionUrnaryOperation(parser, scriptEngine, workEnvironment);
                            value = new RunTime.IsEqualToExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, urnaryOperation);
                            break;
                        }
                    case "<>":
                        {
                            parser.GetNextToken();
                            int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                            var urnaryOperation = ParseExpressionUrnaryOperation(parser, scriptEngine, workEnvironment);
                            value = new RunTime.IsNotEqualToExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, urnaryOperation);
                            break;
                        }
                    case ">=":
                        {
                            parser.GetNextToken();
                            int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                            var urnaryOperation = ParseExpressionUrnaryOperation(parser, scriptEngine, workEnvironment);
                            value = new RunTime.IsGreaterThanOrEqualExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, urnaryOperation);
                            break;
                        }
                    case "<=":
                        {
                            parser.GetNextToken();
                            int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                            var urnaryOperation = ParseExpressionUrnaryOperation(parser, scriptEngine, workEnvironment);
                            value = new RunTime.IsLessThanOrEqualExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, urnaryOperation);
                            break;
                        }
                    case ">":
                        {
                            parser.GetNextToken();
                            int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                            var urnaryOperation = ParseExpressionUrnaryOperation(parser, scriptEngine, workEnvironment);
                            value = new RunTime.IsGreaterThanExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, urnaryOperation);
                            break;
                        }
                    case "<":
                        {
                            parser.GetNextToken();
                            int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                            var urnaryOperation = ParseExpressionUrnaryOperation(parser, scriptEngine, workEnvironment);
                            value = new RunTime.IsLessThanExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, urnaryOperation);
                            break;
                        }

                    default:
                        {
                            done = true;
                            break;
                        }
                }
            }
            while (!done);
            return value;
        }
        private static RunTime.Expression ParseExpressionUrnaryOperation(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            switch (Strings.UCase(parser.PeekNextToken().MatchedText) ?? "")
            {
                case "+":
                    {
                        parser.GetNextToken();
                        int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                        var sum = ParseExpressionSum(parser, scriptEngine, workEnvironment);
                        return new RunTime.PositiveSignedExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), sum);
                    }
                case "-":
                    {
                        parser.GetNextToken();
                        int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                        var sum = ParseExpressionSum(parser, scriptEngine, workEnvironment);
                        return new RunTime.NegativeSignedExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), sum);
                    }

                default:
                    {
                        return ParseExpressionSum(parser, scriptEngine, workEnvironment);
                    }
            }
        }
        private static RunTime.Expression ParseExpressionSum(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            var value = ParseExpressionTerm(parser, scriptEngine, workEnvironment);

            bool done = false;
            do
            {
                switch (Strings.UCase(parser.PeekNextToken().MatchedText) ?? "")
                {
                    case "+":
                        {
                            parser.GetNextToken();
                            int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                            var term = ParseExpressionTerm(parser, scriptEngine, workEnvironment);
                            value = new RunTime.AddExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, term);
                            break;
                        }
                    case "-":
                        {
                            parser.GetNextToken();
                            int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                            var term = ParseExpressionTerm(parser, scriptEngine, workEnvironment);
                            value = new RunTime.SubtractExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, term);
                            break;
                        }

                    default:
                        {
                            // Special processing needs to process language tokens that are signed tokens because the sign should be used as an addition or subtraction operation.
                            if (parser.PeekNextToken().IsPositiveSignedWholeNumber)
                            {
                                ISignedNumberToken token = (ISignedNumberToken)parser.GetNextToken();
                                int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                                value = new RunTime.AddExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, new RunTime.IntegerExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), Conversions.ToInteger(token.UnsignedText)));
                            }
                            else if (parser.PeekNextToken().IsNegativeSignedWholeNumber)
                            {
                                ISignedNumberToken token = (ISignedNumberToken)parser.GetNextToken();
                                int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                                value = new RunTime.SubtractExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, new RunTime.IntegerExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), Conversions.ToInteger(token.UnsignedText)));
                            }
                            else if (parser.PeekNextToken().IsPositiveSignedDecimalNumber)
                            {
                                ISignedNumberToken token = (ISignedNumberToken)parser.GetNextToken();
                                int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                                value = new RunTime.AddExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, new RunTime.DoubleExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), Conversions.ToDouble(token.UnsignedText)));
                            }
                            else if (parser.PeekNextToken().IsNegativeSignedDecimalNumber)
                            {
                                ISignedNumberToken token = (ISignedNumberToken)parser.GetNextToken();
                                int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                                value = new RunTime.SubtractExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, new RunTime.DoubleExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), Conversions.ToDouble(token.UnsignedText)));
                            }
                            else
                            {
                                done = true;
                            }

                            break;
                        }
                }
            }
            while (!done);
            return value;
        }
        private static RunTime.Expression ParseExpressionTerm(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            var value = ParseFactor(parser, scriptEngine, workEnvironment);

            bool done = false;
            do
            {
                switch (Strings.UCase(parser.PeekNextToken().MatchedText) ?? "")
                {
                    case "*":
                        {
                            parser.GetNextToken();
                            int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                            value = new RunTime.MultiplyExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, ParseFactor(parser, scriptEngine, workEnvironment));
                            break;
                        }
                    case "/":
                        {
                            parser.GetNextToken();
                            int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                            value = new RunTime.DivideExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, ParseFactor(parser, scriptEngine, workEnvironment));
                            break;
                        }

                    default:
                        {
                            done = true;
                            break;
                        }
                }
            }
            while (!done);
            return value;
        }
        #endregion

        #region Public Methods
        /// <summary>
    /// Parses an object name.  Used to define objects.  Subscripting is not allowed.  E.g. FOR EACH, DIM etc.  If the object is required to exist and does not exist, a syntax error is thrown; othewise, if the object is required to not exist and it does exist, a syntax error is thrown.
    /// </summary>
    /// <param name="parser"></param>
    /// <param name="workEnvironment"></param>
    /// <returns></returns>
    /// <remarks></remarks>
        public static string ParseObjectName(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment, bool? trueIfMustExistFalseIfMustNotExist)
        {
            string objectName = parser.GetNextToken().MatchedText;
            if (trueIfMustExistFalseIfMustNotExist.HasValue)
            {
                if ((trueIfMustExistFalseIfMustNotExist is var arg1 && !arg1.HasValue || arg1.Value) && !workEnvironment.ObjectExists(objectName) && arg1.HasValue)
                {
                    throw new SyntaxErrorScriptException(objectName + " variable not defined.", parser.CurrentToken());
                }
                else if ((!trueIfMustExistFalseIfMustNotExist is var arg3 && !arg3.HasValue || arg3.Value) && workEnvironment.ObjectExists(objectName) && arg3.HasValue)
                {
                    throw new SyntaxErrorScriptException(objectName + " variable already in use.", parser.CurrentToken());
                }
            }
            return objectName;
        }
        /// <summary>
    /// Parses an object name.  Used to define objects.  Subscripting is not allowed.  E.g. FOR EACH, DIM etc.  If the object is required to exist and does not exist, a syntax error is thrown; othewise, if the object is required to not exist and it does exist, a syntax error is thrown.
    /// </summary>
    /// <param name="parser"></param>
    /// <param name="workEnvironment"></param>
    /// <returns></returns>
    /// <remarks></remarks>
        public static string TryParseObjectName(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            if (!workEnvironment.ObjectExists(parser.PeekNextToken().MatchedText))
            {
                return null;
            }
            else
            {
                return parser.GetNextToken().MatchedText;
            }
        }
        /// <summary>
    /// Parses a keyword.  Throws an exception if the keyword is not found.
    /// </summary>
    /// <param name="parser"></param>
    /// <param name="word"></param>
    /// <remarks></remarks>
        public static void ParseKeyword(Parser parser, string word, bool allowLeadingWhiteSpace = true)
        {
            if (!parser.TryParseKeyword(word, allowLeadingWhiteSpace))
            {
                throw new SyntaxErrorScriptException(word + " expected.", parser.CurrentToken());
            }
        }
        /// <summary>
    /// Parses an expression.  An exception is thrown, if no expression is found.
    /// </summary>
    /// <param name="workEnvironment"></param>
    /// <returns></returns>
    /// <remarks></remarks>
        public static RunTime.Expression ParseExpression(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            var value = ParseExpressionLogicalTerm(parser, scriptEngine, workEnvironment);

            // Ensure an expression was found.
            if (value == null)
            {
                throw new SyntaxErrorScriptException("Expression expected.", parser.GetNextToken());
            }

            var done = default(bool);
            do
            {
                switch (Strings.UCase(parser.PeekNextToken().MatchedText) ?? "")
                {
                    case "OR":
                        {
                            parser.GetNextToken();
                            int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                            var term = ParseExpressionLogicalTerm(parser, scriptEngine, workEnvironment);
                            value = new RunTime.OrExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, term);
                            break;
                        }
                    case "ORELSE":
                        {
                            parser.GetNextToken();
                            int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                            var term = ParseExpressionLogicalTerm(parser, scriptEngine, workEnvironment);
                            value = new RunTime.OrElseExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), value, term);
                            break;
                        }

                    default:
                        {
                            done = true;
                            break;
                        }
                }
            }
            while (!done);
            return value;
        }
        /// <summary>
    /// Attempts to parse a factor from the parser.  If a factor is successfully parsed, it is returned; otherwise, nothing is returned.
    /// </summary>
    /// <param name="parser"></param>
    /// <param name="workEnvironment"></param>
    /// <returns></returns>
    /// <remarks></remarks>
        public static RunTime.Expression ParseFactor(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            var dataValueResolver = TryParseObjectValue(parser, scriptEngine, workEnvironment);
            if (!(dataValueResolver == null))
            {
                return new RunTime.ObjectValueExpression(dataValueResolver.DebugSymbol, dataValueResolver);
            }
            else
            {
                // Loop through all of the predefined commands.
                foreach (FactorParser scriptFunction in scriptEngine.InstalledFactorParsers)
                {
                    var value = scriptFunction.TryParse(parser, scriptEngine, workEnvironment);
                    if (!(value == null))
                    {
                        return value;
                    }
                }
                return null;
            }
        }
        /// <summary>
    /// Parses a reference to an object value; since some objects can have multiple values (arrays etc.); it only returns a single value referenced by an object.  The object must exist.  Used by factors in expressions to retrieve variable data.  The return value is a reference to the value; which can be read from or written to.
    /// </summary>
    /// <param name="parser"></param>
    /// <param name="workEnvironment"></param>
    /// <returns></returns>
    /// <remarks></remarks>
        public static ObjectValue TryParseObjectValue(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
            string objectName = TryParseObjectName(parser, scriptEngine, workEnvironment);
            if (!(objectName == null))
            {
                if (parser.PeekNextToken().MatchedText == "[")
                {
                    parser.GetNextToken();
                    var indexExpression = ParseExpression(parser, scriptEngine, workEnvironment);
                    if (indexExpression == null)
                    {
                        throw new SyntaxErrorScriptException("Script index expected.", parser.CurrentToken());
                    }
                    else
                    {
                        if (parser.GetNextToken().MatchedText != "]")
                        {
                            throw new SyntaxErrorScriptException("] expected at end of script index.", parser.CurrentToken());
                        }
                        var debugSymbol = new DebugSymbol(debugSymbolStart, parser.CurrentToken().StartCharacterIndex);
                        return new ObjectArrayValue(debugSymbol, objectName, indexExpression);
                    }
                }
                else
                {
                    var debugSymbol = new DebugSymbol(debugSymbolStart, parser.CurrentToken().StartCharacterIndex);
                    return new ObjectValue(new DebugSymbol(debugSymbolStart, parser.CurrentToken().StartCharacterIndex), objectName);
                }
            }
            return null;
        }
        public static RunTime.Command[] ParseCommand(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            // Loop through all of the predefined commands.
            foreach (CommandParser scriptCommand in scriptEngine.InstalledCommandParsers)
            {
                var command = scriptCommand.TryParse(parser, scriptEngine, workEnvironment);
                if (!(command == null))
                {
                    return command;
                }
            }

            // Check to see if it is a subroutine.
            var token = parser.PeekNextToken();
            string subroutineName = token.MatchedText;
            var symbol = workEnvironment.TryGetSymbol(subroutineName);
            if (!(symbol == null) && RunTime.Symbol.IsSubroutineSymbol(symbol))
            {
                parser.GetNextToken();

                // Now we need to parse the expressions that are used as parameters to pass to the subroutine.
                RunTime.SubroutineSymbol subroutineSymbol = (RunTime.SubroutineSymbol)symbol;
                RunTime.Expression[] parameters = null;
                if (!(subroutineSymbol.Parameters == null))
                {
                    ParseKeyword(parser, "(");
                    var parameterList = new List<RunTime.Expression>();
                    for (int i = 1, loopTo = subroutineSymbol.Parameters.Length; i <= loopTo; i++)
                    {
                        if (i > 1)
                        {
                            ParseKeyword(parser, ",");
                        }
                        var expression = ParseExpression(parser, scriptEngine, workEnvironment);
                        parameterList.Add(expression);
                    }
                    ParseKeyword(parser, ")");
                    parameters = parameterList.ToArray();
                }
                return new RunTime.Command[] { new RunTime.CallSubroutine(new DebugSymbol(token.StartCharacterIndex, subroutineName), subroutineName, parameters) };
            }
            else
            {
                return null;
            }
        }
        public static string ParseIdentifier(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment, bool allowLeadingWhitespace = true)
        {
            var identifierToken = parser.GetNextToken();
            if (!identifierToken.IsIdentifier)
            {
                throw new SyntaxErrorScriptException("Identifier is not valid.", parser.CurrentToken());
            }
            if (!allowLeadingWhitespace)
            {
                if (!string.IsNullOrEmpty(identifierToken.LeadingWhiteSpace))
                {
                    throw new SyntaxErrorScriptException("Identifier expected.", parser.CurrentToken());
                }
            }
            return identifierToken.MatchedText;
        }
        public static DataType ParseDataType(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            foreach (var dataTypeParser in scriptEngine.InstalledDataTypeParsers)
            {
                // Parse a simple data type.
                var dataType = dataTypeParser.TryParse(parser, workEnvironment);

                // Check to see if the simple data type was found.
                if (!(dataType == null))
                {
                    int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;
                    // Check to see if array subscripts were specified.
                    if (parser.PeekNextToken().MatchedText == "[")
                    {
                        parser.GetNextToken();
                        var length = parser.GetNextToken();
                        if (!(length == null) && length.IsUnsignedWholeNumber && parser.PeekNextToken().MatchedText == "]")
                        {
                            parser.GetNextToken();
                            // Return a data type syntax symbol that represents an array of a simple data type.
                            var debugSymbol = new DebugSymbol(debugSymbolStart, parser.CurrentToken().StartCharacterIndex);
                            return new ArrayDataType(debugSymbol, Conversions.ToInteger(length.MatchedText), dataType);
                        }
                    }
                    else
                    {
                        // Return a data type syntax symbol that represents a simple data type.
                        return dataType;
                    }
                }
            }
            throw new SyntaxErrorScriptException("Data type expected.", parser.PeekNextToken()); // The next token doesn't seem to be a data type.
        }
        /// <summary>
    /// Parses an object value.  If an object value is not found, an exception is thrown.
    /// </summary>
    /// <param name="parser"></param>
    /// <param name="workEnvironment"></param>
    /// <returns></returns>
    /// <remarks></remarks>
        public static ObjectValue ParseObjectValue(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            var dataValueResolver = TryParseObjectValue(parser, scriptEngine, workEnvironment);
            if (dataValueResolver == null)
            {
                throw new SyntaxErrorScriptException("Unknown object or object expected.", parser.PeekNextToken());
            }
            return dataValueResolver;
        }
        public static RunTime.Command[] TryParseCommands(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            var commandList = new List<RunTime.Command>();
            RunTime.Command[] commands;
            do
            {
                commands = ParseCommand(parser, scriptEngine, workEnvironment);
                if (!(commands == null))
                {
                    commandList.AddRange(commands);
                }
            }
            while (commands != null);
            return commandList.ToArray();
        }
        #endregion

    }
}