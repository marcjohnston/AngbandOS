using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class Parenthesis : Expression
    {

        public readonly Expression Expression;
        // Protected Overrides Function CreateTreeNode() As ScriptTreeNode
        // Return New ScriptTreeNode(Me, "()", New ScriptTreeNode(Expression))
        // End Function
        public override object ToText()
        {
            return "(" + Conversions.ToString(Expression.ToText()) + ")";
        }
        protected override DataValue DoCompute(Job job)
        {
            return Expression.Compute(job);
        }
        public Parenthesis(Expression expression) : this(null, expression)
        {
        }
        public Parenthesis(DebugSymbol debugSymbol, Expression expression) : base(debugSymbol)
        {
            Expression = expression;
        }
    }
}