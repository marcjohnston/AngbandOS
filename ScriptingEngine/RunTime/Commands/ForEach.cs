using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class ForEach : Command
    {

        public readonly string ObjectName;
        public readonly Expression Expression;
        public readonly Command[] Commands;
        protected override void DoExecute(Job job, WorkEnvironment workEnvironment)
        {
            var value = Expression.Compute(job);
            if (!typeof(IEnumerable).IsAssignableFrom(value.GetType()))
            {
                throw new RunTimeErrorScriptException("For loop expression is not enumerable.");
            }
            else
            {
                var enumerator = ((IEnumerable)value).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    // Get the next enumeration.
                    DataValue currentEnumerator = (DataValue)enumerator.Current;

                    // Create the object variable.
                    job.WorkEnvironment.PushScope();
                    var symbol = new ObjectSymbol(ObjectName);
                    symbol.Value = currentEnumerator;
                    job.WorkEnvironment.AddSymbol(ObjectName, symbol);

                    ExecuteCommands(job, workEnvironment, Commands);

                    // Delete the temporary object.  The go round will recreate it, otherwise we don't want it.
                    job.WorkEnvironment.PopScope();

                    if (job.StopJobPending)
                    {
                        return;
                    }
                }
            }
        }
        public override object ToText()
        {
            var s = new List<string>();
            s.Add("FOR EACH " + ObjectName + " IN " + Conversions.ToString(Expression.ToText()));
            foreach (Command command in Commands)
                s.Add(Conversions.ToString(command.ToText()));
            s.Add("NEXT");
            return s.ToArray();
        }
        public override ScriptTreeNode ToTreeNode()
        {
            var children = new List<ScriptTreeNode>();
            children.Add(new ScriptTreeNode(null, "Object Name =" + ObjectName));
            children.Add(Expression.ToTreeNode());
            foreach (Command command in Commands)
                children.Add(command.ToTreeNode());
            return new ScriptTreeNode(this, "FOR EACH ", children.ToArray());
        }
        public ForEach(string objectName, Expression expression, Command[] commands) : this(null, objectName, expression, commands)
        {
        }
        public ForEach(DebugSymbol debugSymbol, string objectName, Expression expression, Command[] commands) : base(debugSymbol)
        {
            ObjectName = objectName;
            Expression = expression;
            Commands = commands;
        }
    }
}