using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class IfThenElse : Command
    {

        public readonly Expression Expression;
        public readonly Command[] IfTrueCommands;
        public readonly Command[] IfFalseCommands;
        protected override void DoExecute(Job job, WorkEnvironment workEnvironment)
        {
            var value = Expression.Compute(job);
            if (!value.IsBoolean())
            {
                throw new RunTimeErrorScriptException("If expression did not evaluate to a boolean expression.");
            }
            if (((BooleanValue)value).Value)
            {
                if (!(IfTrueCommands == null))
                {
                    ExecuteCommands(job, workEnvironment, IfTrueCommands);
                }
            }
            else if (!(IfFalseCommands == null))
            {
                ExecuteCommands(job, workEnvironment, IfFalseCommands);
            }
        }
        public override object ToText()
        {
            var s = new List<string>();
            s.Add("IF " + Conversions.ToString(Expression.ToText()) + " THEN");
            foreach (Command command in IfTrueCommands)
                s.Add(Conversions.ToString(command.ToText()));
            if (!(IfFalseCommands == null))
            {
                s.Add("ELSE");
                foreach (Command command in IfFalseCommands)
                    s.Add(Conversions.ToString(command.ToText()));
            }
            s.Add("END IF");
            return s.ToArray();
        }
        public override ScriptTreeNode ToTreeNode()
        {
            if (IfFalseCommands == null)
            {
                return new ScriptTreeNode(this, "IF", new ScriptTreeNode(Expression, "Test Expression", Expression.ToTreeNode()), new ScriptTreeNode("THEN", IfTrueCommands));
            }
            else
            {
                return new ScriptTreeNode(this, "IF", new ScriptTreeNode(Expression, "Test Expression", Expression.ToTreeNode()), new ScriptTreeNode("THEN", IfTrueCommands), new ScriptTreeNode("ELSE", IfFalseCommands));
            }
        }
        public IfThenElse(Expression expression, Command[] ifTrue) : this(null, expression, ifTrue, null)
        {
        }
        public IfThenElse(DebugSymbol debugSymbol, Expression expression, Command[] ifTrue) : this(debugSymbol, expression, ifTrue, null)
        {
        }
        public IfThenElse(Expression expression, Command[] ifTrue, Command[] ifFalse) : this(null, expression, ifTrue, ifFalse)
        {
        }
        public IfThenElse(DebugSymbol debugSymbol, Expression expression, Command[] ifTrue, Command[] ifFalse) : base(debugSymbol)
        {
            Expression = expression;
            IfTrueCommands = ifTrue;
            IfFalseCommands = ifFalse;
        }
    }
}