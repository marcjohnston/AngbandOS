using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class DoUntilLoop : Command
    {

        public readonly Command[] Commands;
        public readonly Expression Expression;
        protected override void DoExecute(Job job, WorkEnvironment workEnvironment)
        {
            while (!Expression.Compute(job).IsTrue())
            {
                ExecuteCommands(job, workEnvironment, Commands);

                if (job.StopJobPending)
                {
                    return;
                }
            }
        }
        public override ScriptTreeNode ToTreeNode()
        {
            return new ScriptTreeNode(this, "DO LOOP", new ScriptTreeNode(null, "UNTIL", Expression.ToTreeNode()), new ScriptTreeNode(Commands));
        }
        public override object ToText()
        {
            var s = new List<string>();
            s.Add("DO UNTIL " + Conversions.ToString(Expression.ToText()));
            foreach (Command command in Commands)
                s.Add(Conversions.ToString(command.ToText()));
            s.Add("LOOP");
            return s.ToArray();
        }
        public DoUntilLoop(Command[] commands, Expression expression) : this(null, commands, expression)
        {
        }
        public DoUntilLoop(DebugSymbol debugSymbol, Command[] commands, Expression expression) : base(debugSymbol)
        {
            Commands = commands;
            Expression = expression;
        }
    }
}