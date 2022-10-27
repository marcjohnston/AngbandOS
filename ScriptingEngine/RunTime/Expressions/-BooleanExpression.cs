
// Namespace RunTime
// Public Class BooleanExpression2
// Inherits Expression

// Public ReadOnly Value As Boolean
// Public Overrides Function ToText() As Object
// Return IIf(Value, "TRUE", "FALSE")
// End Function
// Protected Overrides Function DoCompute(job As Job) As DataValue
// Return New BooleanValue(Value)
// End Function
// Public Sub New(value As Boolean)
// Me.New(Nothing, value)
// End Sub
// Public Sub New(debugSymbol As DebugSymbol, value As Boolean)
// MyBase.New(debugSymbol)
// Me.Value = value
// End Sub
// End Class
// End Namespace