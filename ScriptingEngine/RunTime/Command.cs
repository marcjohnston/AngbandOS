
namespace Big6Search.ScriptingEngine.RunTime
{
    public abstract class Command : RunTimeObject
    {

        public void ExecuteCommands(Job job, WorkEnvironment workEnvironment, Command[] commands)
        {
            // Loop through all of the commands in the for loop.
            foreach (Command command in commands)
            {
                command.Execute(job, workEnvironment);

                if (job.StopJobPending)
                {
                    return;
                }
            }
        }
        public void Execute(Job job, WorkEnvironment workEnvironment)
        {
            OnExecutingEvent(job);

            // Allow the job to handle debug mode.
            job.ProcessPreCommand();

            DoExecute(job, workEnvironment);
        }
        protected abstract void DoExecute(Job job, WorkEnvironment workEnvironment);
        public Command(DebugSymbol debugSymbol) : base(debugSymbol)
        {
        }
    }
}