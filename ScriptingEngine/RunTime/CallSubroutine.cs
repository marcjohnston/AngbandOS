using System;

namespace Big6Search.ScriptingEngine.RunTime
{
    public class CallSubroutine : Command
    {

        public readonly string SubroutineName;
        public readonly Expression[] Parameters;
        protected override void DoExecute(Job job, WorkEnvironment workEnvironment)
        {
            var symbol = workEnvironment.GetSymbol(SubroutineName);
            if (!Symbol.IsSubroutineSymbol(symbol))
            {
                throw new Exception("Symbol is not subroutine.");
            }
            SubroutineSymbol subroutineSymbol = (SubroutineSymbol)symbol;

            workEnvironment.PushScope();
            // Create all of the local parameters.
            if (!(subroutineSymbol.Parameters == null))
            {
                for (int i = 0, loopTo = subroutineSymbol.Parameters.Length - 1; i <= loopTo; i++)
                {
                    // Get the name of the parameter that the subroutine defines.
                    string parameterName = subroutineSymbol.Parameters[i].Name;

                    // Create the parameter symbol.
                    var parameterSymbol = new ObjectSymbol(parameterName);

                    // Compute the value of the parameter that needs to be passed to the subroutine and assign it to the parameter symbol.
                    parameterSymbol.Value = Parameters[i].Compute(job);

                    // Add the symbol to the scope.
                    workEnvironment.AddSymbol(parameterName, parameterSymbol);
                }
            }
            ExecuteCommands(job, workEnvironment, ((SubroutineSymbol)symbol).Commands);
            workEnvironment.PopScope();
        }
        public CallSubroutine(DebugSymbol debugSymbol, string subroutineName, Expression[] parameters) : base(debugSymbol)
        {
            SubroutineName = subroutineName;
            Parameters = parameters;
        }
    }
}