using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class For : Command
    {

        public readonly string ObjectName;
        public readonly Expression StartExpression;
        public readonly Expression EndExpression;
        public readonly Expression StepExpression;
        public readonly Command[] Commands;
        protected override void DoExecute(Job job, WorkEnvironment workEnvironment)
        {
            IntegerValue startValue = (IntegerValue)StartExpression.Compute<IntegerValue>(job, false);
            IntegerValue endValue = (IntegerValue)EndExpression.Compute<IntegerValue>(job, false);
            IntegerValue stepValue = (IntegerValue)StepExpression.Compute<IntegerValue>(job, false);

            for (int i = startValue.Value, loopTo = endValue.Value; stepValue.Value >= 0 ? i <= loopTo : i >= loopTo; i += stepValue.Value)
            {
                job.WorkEnvironment.PushScope();

                // Create the object variable.
                var symbol = new ObjectSymbol(ObjectName);
                symbol.Value = new IntegerValue(i);
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
        public override object ToText()
        {
            var s = new List<string>();
            s.Add("FOR " + ObjectName + " = " + Conversions.ToString(StartExpression.ToText()) + " TO " + Conversions.ToString(EndExpression.ToText()));
            foreach (Command command in Commands)
                s.Add(Conversions.ToString(command.ToText()));
            s.Add("NEXT");
            return s.ToArray();
        }
        public override ScriptTreeNode ToTreeNode()
        {
            var children = new List<ScriptTreeNode>();
            children.Add(new ScriptTreeNode(null, "Object Name =" + ObjectName));
            children.Add(StartExpression.ToTreeNode());
            children.Add(EndExpression.ToTreeNode());
            children.Add(StepExpression.ToTreeNode());
            foreach (Command command in Commands)
                children.Add(command.ToTreeNode());
            return new ScriptTreeNode(this, "FOR ", children.ToArray());
        }
        public For(string objectName, Expression startExpression, Expression endExpression, Expression stepExpression, Command[] commands) : this(null, objectName, startExpression, endExpression, stepExpression, commands)
        {
        }
        public For(DebugSymbol debugSymbol, string objectName, Expression startExpression, Expression endExpression, Expression stepExpression, Command[] commands) : base(debugSymbol)
        {
            ObjectName = objectName;
            StartExpression = startExpression;
            EndExpression = endExpression;
            StepExpression = stepExpression;
            Commands = commands;
        }
    }
}