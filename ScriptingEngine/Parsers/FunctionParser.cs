using System.Collections.Generic;
using byMarc.Net2.Library.LanguageParsing;
using Microsoft.VisualBasic;

namespace Big6Search.ScriptingEngine
{

    #region FunctionParser - Represents a base class that allows derived classes to define and implement a standarized function without performing all of the parsing work.  Structured functions follow the syntax: Function, Function() or Function(parameter1[, parameter2...]).  Optional parameters are also supported.
    /// <summary>
#Region "FunctionParser - Represents a base class that allows derived classes to define and implement a standarized function without performing all of the parsing work.  Structured functions follow the syntax: Function, Function() or Function(parameter1[, parameter2...]).  Optional parameters are also supported."/// Represents a base class that allows derived classes to define and implement a standarized function without performing all of the parsing work.  Structured functions follow the syntax Function, Function() or Function(parameter1[, parameter2...]).  Optional parameters are also supported.
#Region "FunctionParser - Represents a base class that allows derived classes to define and implement a standarized function without performing all of the parsing work.  Structured functions follow the syntax: Function, Function() or Function(parameter1[, parameter2...]).  Optional parameters are also supported."/// </summary>
#Region "FunctionParser - Represents a base class that allows derived classes to define and implement a standarized function without performing all of the parsing work.  Structured functions follow the syntax: Function, Function() or Function(parameter1[, parameter2...]).  Optional parameters are also supported."/// <remarks></remarks>
    public abstract class FunctionParser : FactorParser
    {

        protected abstract FunctionParameterParser[] ParameterParsers { get; }
        protected abstract string FunctionName { get; }
        protected abstract RunTime.Expression CreateExpression(DebugSymbol debugSymbol, RunTime.ParameterSymbol[] parameterSymbols);
        public sealed override RunTime.Expression TryParse(Parser parser, ScriptEngine scriptEngine, RunTime.WorkEnvironment workEnvironment)
        {
            if ((Strings.UCase(parser.PeekNextToken().MatchedText) ?? "") == (Strings.UCase(FunctionName) ?? ""))
            {
                // Retrieve and dispose of the function name.
                parser.GetNextToken();

                // This is where we want the debug symbol to point to.
                int debugSymbolStart = parser.CurrentToken().StartCharacterIndex;

                // Get the parameter definitions.  Since this operation will typicall involve the inheriting class to build and assembly an array and we will need to access it several times, we will force the
                // inheriting class to do the work and then we will save it.
                var parameterDeclarations = ParameterParsers;

                // If the derived function defined parameter declarations, we need to validate them and determine if any and/or all of them are required or optional.
                bool anyRequired = false;
                bool anyOptional = false;
                bool allOptional = true;
                if (!(parameterDeclarations == null))
                {
                    foreach (FunctionParameterParser parameterDeclaration in parameterDeclarations)
                    {
                        if (!parameterDeclaration.IsOptional)
                        {
                            if (anyOptional)
                            {
                                throw new SyntaxErrorScriptException("Optional parameters cannot be declared after required parameters.  Function " + FunctionName + ".", parser.CurrentToken());
                            }
                            anyRequired = true;
                            allOptional = false;
                        }
                        else
                        {
                            anyOptional = true;
                        }
                    }
                }

                // Define storage for the parameters that are parsed.
                var parsedParameters = new List<RunTime.ParameterSymbol>();

                // Check to see if the parenthesis were omitted in the script.
                if (parser.PeekNextToken().MatchedText != "(")
                {
                    // If all parameters are optional or the parameter definitions returned nothing or the parameter definitions returned an empty array, then the omitted parenthesis are valid.
                    if (parameterDeclarations == null || parameterDeclarations.Length > 0 || allOptional)
                    {
                        // The function call omit the parenthesis.
                        return CreateExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), parsedParameters.ToArray());
                    }
                    else
                    {
                        throw new SyntaxErrorScriptException("( missing.", parser.CurrentToken());
                    }
                }

                // Discard the open parenthesis.
                parser.GetNextToken();

                // Dervied functions that return nothing as parameter declarations do not accept an empty parenthesis as valid in the script.
                if (parameterDeclarations == null)
                {
                    throw new SyntaxErrorScriptException("Then keyword expected.", parser.CurrentToken());
                }

                // Check to see if the empty parenthesis was specified.
                if (parser.PeekNextToken().MatchedText == ")")
                {
                    // Discard the open parenthesis.
                    parser.GetNextToken();

                    // If all parameters are optional or the parameter definitions returned nothing or the parameter definitions returned an empty array, then the empty parenthesis is valid.
                    if (parameterDeclarations == null || parameterDeclarations.Length > 0 || allOptional)
                    {
                        // The function call specified empty parenthesis.
                        return CreateExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), parsedParameters.ToArray());
                    }
                    else
                    {
                        throw new SyntaxErrorScriptException("Expression missing.", parser.CurrentToken());
                    }
                }

                // At this point there is at least one or more required or optional parameters specified.  Start matching them up.
                int parameterIndex = 0;
                do
                {
                    // Parse the parameter.
                    var parameter = parameterDeclarations[parameterIndex].TryParse(parser, scriptEngine, workEnvironment);

                    // Add the parameter to the list of parsed parameters.
                    parsedParameters.Add(parameter);

                    // Go to the next parameter.
                    parameterIndex += 1;

                    // Check to see if there are no more parameters specified.
                    if (parser.PeekNextToken().MatchedText == ")")
                    {
                        // Discard the closing parenthesis.
                        parser.GetNextToken();

                        // Make sure there are no more parameters defined or that the rest of the parameter definitions are optional.
                        if (parameterDeclarations.Length == parameterIndex || parameterDeclarations[parameterIndex].IsOptional)
                        {
                            // One or more parameters were omitted.
                            return CreateExpression(new DebugSymbol(debugSymbolStart, parser.CurrentToken().EndCharacterIndex), parsedParameters.ToArray());
                        }
                        else
                        {
                            throw new SyntaxErrorScriptException("Expression missing.", parser.CurrentToken());
                        }
                    }

                    // Make sure there are more parameters defined.
                    if (parameterDeclarations.Length == parameterIndex)
                    {
                        throw new SyntaxErrorScriptException(") expected.", parser.CurrentToken());
                    }

                    // Check to see if a comma was specified in the script.
                    if (parser.PeekNextToken().MatchedText == ",")
                    {
                        parser.GetNextToken();
                    }

                    // Check to see if the rest of the parameters are optional.
                    else if (parameterDeclarations[parameterIndex].IsOptional)
                    {
                        throw new SyntaxErrorScriptException(") expected", parser.CurrentToken());
                    }
                    else
                    {
                        throw new SyntaxErrorScriptException(", expected", parser.CurrentToken());
                    }
                }
                while (true);
            }
            else
            {
                return null;
            }
        }
    }
}
#endregion
