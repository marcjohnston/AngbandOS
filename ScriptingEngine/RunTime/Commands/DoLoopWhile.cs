using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class DoLoopWhile : Command
    {

        public readonly Command[] Commands;
        public readonly Expression Expression;
        protected override void DoExecute(Job job, WorkEnvironment workEnvironment)
        {
            do
            {
                ExecuteCommands(job, workEnvironment, Commands);

                if (job.StopJobPending)
                {
                    return;
                }
            }
            while (Expression.Compute(job).IsTrue());
        }
        public override ScriptTreeNode ToTreeNode()
        {
            return new ScriptTreeNode(this, "DO LOOP", new ScriptTreeNode(Commands), new ScriptTreeNode(null, "WHILE", Expression.ToTreeNode()));
        }
        public override object ToText()
        {
            var s = new List<string>();
            s.Add("DO");
            foreach (Command command in Commands)
                s.Add(Conversions.ToString(command.ToText()));
            s.Add("LOOP WHILE " + Conversions.ToString(Expression.ToText()));
            return s.ToArray();
        }
        public DoLoopWhile(Command[] commands, Expression expression) : this(null, commands, expression)
        {
        }
        public DoLoopWhile(DebugSymbol debugSymbol, Command[] commands, Expression expression) : base(debugSymbol)
        {
            Commands = commands;
            Expression = expression;
        }
    }
}