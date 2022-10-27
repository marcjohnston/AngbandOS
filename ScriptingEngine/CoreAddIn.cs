using System;

namespace Big6Search.ScriptingEngine
{

    public class CoreAddIn : AddIn
    {

        // #Region "Private, Protected & Friends"
        // Private Shared Function ParseExpressionLogicalTerm(parser As Parser, workEnvironment As RunTime.WorkEnvironment) As RunTime.Expression
        // Dim value As RunTime.Expression = ParseExpressionMagnitideComparator(parser, workEnvironment)

        // Dim done As Boolean = False
        // Do
        // Select Case UCase(parser.PeekNextToken.MatchedText)
        // Case "AND"
        // parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // Dim magnitudeComparator As RunTime.Expression = ParseExpressionMagnitideComparator(parser, workEnvironment)
        // value = New RunTime.AndExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, magnitudeComparator)
        // Case "ANDALSO"
        // parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // Dim magnitudeComparator As RunTime.Expression = ParseExpressionMagnitideComparator(parser, workEnvironment)
        // value = New RunTime.AndAlsoExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, magnitudeComparator)
        // Case Else
        // done = True
        // End Select
        // Loop Until done
        // Return value
        // End Function
        // Private Shared Function ParseExpressionMagnitideComparator(parser As Parser, workEnvironment As RunTime.WorkEnvironment) As RunTime.Expression
        // Dim value As RunTime.Expression = ParseExpressionUrnaryOperation(parser, workEnvironment)

        // Dim done As Boolean = False
        // Do
        // Select Case UCase(parser.PeekNextToken.MatchedText)
        // Case "="
        // parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // Dim urnaryOperation As RunTime.Expression = ParseExpressionUrnaryOperation(parser, workEnvironment)
        // value = New RunTime.IsEqualToExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, urnaryOperation)
        // Case "<>"
        // parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // Dim urnaryOperation As RunTime.Expression = ParseExpressionUrnaryOperation(parser, workEnvironment)
        // value = New RunTime.IsNotEqualToExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, urnaryOperation)
        // Case ">="
        // parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // Dim urnaryOperation As RunTime.Expression = ParseExpressionUrnaryOperation(parser, workEnvironment)
        // value = New RunTime.IsGreaterThanOrEqualExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, urnaryOperation)
        // Case "<="
        // parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // Dim urnaryOperation As RunTime.Expression = ParseExpressionUrnaryOperation(parser, workEnvironment)
        // value = New RunTime.IsLessThanOrEqualExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, urnaryOperation)
        // Case ">"
        // parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // Dim urnaryOperation As RunTime.Expression = ParseExpressionUrnaryOperation(parser, workEnvironment)
        // value = New RunTime.IsGreaterThanExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, urnaryOperation)
        // Case "<"
        // parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // Dim urnaryOperation As RunTime.Expression = ParseExpressionUrnaryOperation(parser, workEnvironment)
        // value = New RunTime.IsLessThanExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, urnaryOperation)
        // Case Else
        // done = True
        // End Select
        // Loop Until done
        // Return value
        // End Function
        // Private Shared Function ParseExpressionUrnaryOperation(parser As Parser, workEnvironment As RunTime.WorkEnvironment) As RunTime.Expression
        // Select Case UCase(parser.PeekNextToken.MatchedText)
        // Case "+"
        // parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // Dim sum As RunTime.Expression = ParseExpressionSum(parser, workEnvironment)
        // Return New RunTime.PositiveSignedExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), sum)
        // Case "-"
        // parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // Dim sum As RunTime.Expression = ParseExpressionSum(parser, workEnvironment)
        // Return New RunTime.NegativeSignedExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), sum)
        // Case Else
        // Return ParseExpressionSum(parser, workEnvironment)
        // End Select
        // End Function
        // Private Shared Function ParseExpressionSum(parser As Parser, workEnvironment As RunTime.WorkEnvironment) As RunTime.Expression
        // Dim value As RunTime.Expression = ParseExpressionTerm(parser, workEnvironment)

        // Dim done As Boolean = False
        // Do
        // Select Case UCase(parser.PeekNextToken.MatchedText)
        // Case "+"
        // parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // Dim term As RunTime.Expression = ParseExpressionTerm(parser, workEnvironment)
        // value = New RunTime.AddExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, term)
        // Case "-"
        // parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // Dim term As RunTime.Expression = ParseExpressionTerm(parser, workEnvironment)
        // value = New RunTime.SubtractExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, term)
        // Case Else
        // ' Special processing needs to process language tokens that are signed tokens because the sign should be used as an addition or subtraction operation.
        // If parser.PeekNextToken.IsPositiveSignedWholeNumber Then
        // Dim token As ISignedNumberToken = parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // value = New RunTime.AddExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, New RunTime.IntegerExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), token.UnsignedText))
        // ElseIf parser.PeekNextToken.IsNegativeSignedWholeNumber Then
        // Dim token As ISignedNumberToken = parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // value = New RunTime.SubtractExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, New RunTime.IntegerExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), token.UnsignedText))
        // ElseIf parser.PeekNextToken.IsPositiveSignedDecimalNumber Then
        // Dim token As ISignedNumberToken = parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // value = New RunTime.AddExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, New RunTime.DoubleExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), token.UnsignedText))
        // ElseIf parser.PeekNextToken.IsNegativeSignedDecimalNumber Then
        // Dim token As ISignedNumberToken = parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // value = New RunTime.SubtractExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, New RunTime.DoubleExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), token.UnsignedText))
        // Else
        // done = True
        // End If
        // End Select
        // Loop Until done
        // Return value
        // End Function
        // Private Shared Function ParseExpressionTerm(parser As Parser, workEnvironment As RunTime.WorkEnvironment) As RunTime.Expression
        // Dim value As RunTime.Expression = ParseObject(parser, workEnvironment)

        // Dim done As Boolean = False
        // Do
        // Select Case UCase(parser.PeekNextToken.MatchedText)
        // Case "*"
        // parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // value = New RunTime.MultiplyExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, ParseObject(parser, workEnvironment))
        // Case "/"
        // parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // value = New RunTime.DivideExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, ParseObject(parser, workEnvironment))
        // Case Else
        // done = True
        // End Select
        // Loop Until done
        // Return value
        // End Function
        // Private Shared Function ParseObject(parser As Parser, workEnvironment As RunTime.WorkEnvironment) As RunTime.Expression
        // Dim dataValueResolver As ObjectDataValue = TryParseDataValue(parser, workEnvironment)
        // If IsNothing(dataValueResolver) Then
        // Return ParseFactor(parser, workEnvironment)
        // Else
        // Return New RunTime.ObjectValueExpression(dataValueResolver.DebugSymbol, dataValueResolver)
        // End If
        // End Function
        // #End Region

        // #Region "Public Shared Methods"
        // ''' <summary>
        // ''' Parses an object name.  If the object does not exist, an syntax error is thrown.
        // ''' </summary>
        // ''' <param name="parser"></param>
        // ''' <param name="workEnvironment"></param>
        // ''' <returns></returns>
        // ''' <remarks></remarks>
        // Public Shared Function ParseObjectName(parser As Parser, workEnvironment As RunTime.WorkEnvironment, trueIfMustExistFalseIfMustNotExist As Boolean) As String
        // Dim objectName As String = parser.GetNextToken.MatchedText
        // If trueIfMustExistFalseIfMustNotExist AndAlso Not workEnvironment.ObjectExists(objectName) Then
        // Throw New SyntaxErrorScriptException(objectName + " variable not defined.", parser.CurrentToken)
        // ElseIf Not trueIfMustExistFalseIfMustNotExist AndAlso workEnvironment.ObjectExists(objectName) Then
        // Throw New SyntaxErrorScriptException(objectName + " variable already in use.", parser.CurrentToken)
        // End If
        // Return objectName
        // End Function
        // ''' <summary>
        // ''' Parses a keyword.  Throws an exception if the keyword was not found.
        // ''' </summary>
        // ''' <param name="parser"></param>
        // ''' <param name="word"></param>
        // ''' <remarks></remarks>
        // Public Shared Sub ParseKeyword(parser As Parser, word As String)
        // If UCase(parser.PeekNextToken.MatchedText) = UCase(word) Then
        // ' Toss the keyword.
        // parser.GetNextToken()
        // Else
        // Throw New SyntaxErrorScriptException(word + " keyword expected.", parser.CurrentToken)
        // End If
        // End Sub
        // ''' <summary>
        // ''' Tries to parse a keyword.  Returns TRUE, if the keyword was found; false, otherwise.
        // ''' </summary>
        // ''' <param name="parser"></param>
        // ''' <param name="word"></param>
        // ''' <returns></returns>
        // ''' <remarks></remarks>
        // Public Shared Function TryParseKeyword(parser As Parser, word As String) As Boolean
        // If UCase(parser.PeekNextToken.MatchedText) = UCase(word) Then
        // ' Toss the keyword.
        // parser.GetNextToken()
        // TryParseKeyword = True
        // Else
        // TryParseKeyword = False
        // End If
        // End Function
        // ''' <summary>
        // ''' Parses an expression.  An exception is thrown, if no expression is found.
        // ''' </summary>
        // ''' <param name="workEnvironment"></param>
        // ''' <returns></returns>
        // ''' <remarks></remarks>
        // Public Shared Function ParseExpression(parser As Parser, workEnvironment As RunTime.WorkEnvironment) As RunTime.Expression
        // Dim value As RunTime.Expression = ParseExpressionLogicalTerm(parser, workEnvironment)

        // ' Ensure an expression was found.
        // If IsNothing(value) Then
        // Throw New SyntaxErrorScriptException("Expression expected.", parser.GetNextToken)
        // End If

        // Dim done As Boolean
        // Do
        // Select Case UCase(parser.PeekNextToken.MatchedText)
        // Case "OR"
        // parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // Dim term As RunTime.Expression = ParseExpressionLogicalTerm(parser, workEnvironment)
        // value = New RunTime.OrExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, term)
        // Case "ORELSE"
        // parser.GetNextToken()
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // Dim term As RunTime.Expression = ParseExpressionLogicalTerm(parser, workEnvironment)
        // value = New RunTime.OrElseExpression(New DebugSymbol(debugSymbolStart, parser.CurrentToken.EndCharacterIndex), value, term)
        // Case Else
        // done = True
        // End Select
        // Loop Until done
        // Return value
        // End Function
        // Public Shared Function TryParseDataValue(parser As Parser, workEnvironment As RunTime.WorkEnvironment) As ObjectDataValue
        // Dim debugSymbolStart As Integer = parser.CurrentToken.StartCharacterIndex
        // If workEnvironment.ObjectExists(parser.PeekNextToken.MatchedText) Then
        // Dim objectName As String = parser.GetNextToken.MatchedText
        // If parser.PeekNextToken.MatchedText = "[" Then
        // parser.GetNextToken()
        // Dim indexExpression As RunTime.Expression = ParseExpression(parser, workEnvironment)
        // If IsNothing(indexExpression) Then
        // Throw New SyntaxErrorScriptException("Script index expected.", parser.CurrentToken)
        // Else
        // If parser.GetNextToken.MatchedText <> "]" Then
        // Throw New SyntaxErrorScriptException("] expected at end of script index.", parser.CurrentToken)
        // End If
        // Dim debugSymbol As New DebugSymbol(debugSymbolStart, parser.CurrentToken.StartCharacterIndex)
        // Return New ObjectArrayDataValue(debugSymbol, objectName, indexExpression)
        // End If
        // Else
        // Dim debugSymbol As New DebugSymbol(debugSymbolStart, parser.CurrentToken.StartCharacterIndex)
        // Return New ObjectDataValue(New DebugSymbol(debugSymbolStart, parser.CurrentToken.StartCharacterIndex), objectName)
        // End If
        // End If
        // Return Nothing
        // End Function
        // Public Shared Function ParseFactor(parser As Parser, workEnvironment As RunTime.WorkEnvironment) As RunTime.Expression
        // ' Loop through all of the predefined commands.
        // For Each scriptFunction As FactorParser In workEnvironment.ScriptEngine.InstalledFactorParsers
        // Dim value As RunTime.Expression = scriptFunction.TryParse(parser, workEnvironment)
        // If Not IsNothing(value) Then
        // Return value
        // End If
        // Next

        // Return Nothing
        // End Function
        // Public Shared Function ParseCommands(parser As Parser, workEnvironment As RunTime.WorkEnvironment) As RunTime.Command()
        // Dim commands As New List(Of RunTime.Command)
        // Dim command As RunTime.Command
        // Do
        // command = ParseCommand(parser, workEnvironment)
        // If Not IsNothing(command) Then
        // commands.Add(command)
        // End If
        // Loop Until IsNothing(command)
        // Return commands.ToArray
        // End Function
        // Public Shared Function ParseCommand(parser As Parser, workEnvironment As RunTime.WorkEnvironment) As RunTime.Command
        // ' Loop through all of the predefined commands.
        // For Each scriptCommand As CommandParser In workEnvironment.ScriptEngine.InstalledCommandParsers
        // Dim command As RunTime.Command = scriptCommand.TryParse(parser, workEnvironment)
        // If Not IsNothing(command) Then
        // Return command
        // End If
        // Next
        // Return Nothing
        // End Function
        // Public Shared Sub ParseSymbol(parser As Parser, symbol As String)
        // Dim currentToken As ParsedToken = parser.GetNextToken
        // If UCase(currentToken.MatchedText) <> UCase(symbol) Then
        // Throw New SyntaxErrorScriptException(symbol + " expected.", parser.CurrentToken)
        // End If
        // End Sub
        // #End Region

        #region Public Properties
        public override Guid Guid
        {
            get
            {
                return new Guid("407000f4-32eb-41f1-a370-e15344adae1d");
            }
        }
        public override string Title
        {
            get
            {
                return "Core";
            }
        }
        public override string Description
        {
            get
            {
                return "Implements the core data types, factors and other basic scripting commands.";
            }
        }
        public override CommandParser[] CommandParsers
        {
            get
            {
                return new CommandParser[] { new CommentCommandParser(), new DoLoopCommandParser(), new ForCommandParser(), new IfThenElseCommandParser(), new SetCommandParser(), new StopCommandParser(), new WaitCommandParser(), new SetProgressCommandParser(), new SetProgressStageCommandParser(), new SetProgressMaxCommandParser(), new BreakParser(), new DimCommandParser(), new Sub() };
            }
        }
        public override FactorParser[] FactorParsers
        {
            get
            {
                return new FactorParser[] { new LiteralFactorParser(), new TrueFunctionParser(), new FalseFunctionParser(), new CountScriptFactor(), new IsNothingFunctionParser(), new NotFactorParser(), new IntegerFactorParser(), new ParenthesisFactorParser(), new TokenFunctionParser(), new NothingFunctionParser(), new NowFunctionParser(), new InStrParser() };
            }
        }
        public override DataTypeParser[] DataTypeParsers
        {
            get
            {
                return new DataTypeParser[] { new BooleanDataTypeParser(), new IntegerDataTypeParser(), new DoubleDataTypeParser(), new StringDataTypeParser(), new DateTimeDataTypeParser() };
            }
        }
        #endregion

    }
}