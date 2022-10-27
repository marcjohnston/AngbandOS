
namespace Big6Search.ScriptingEngine.RunTime
{
    public class Sub : Command
    {
        public readonly string Name;
        public readonly ParameterDefinition[] ParameterDefinitions;
        public readonly Command[] Commands;
        protected override void DoExecute(Job job, WorkEnvironment workEnvironment)
        {
            var subroutineSymbol = new SubroutineSymbol(Name);
            subroutineSymbol.Commands = Commands;
            subroutineSymbol.Parameters = ParameterDefinitions;
            workEnvironment.AddSymbol(Name, subroutineSymbol);
        }
        public Sub(DebugSymbol debugSymbol, string name, ParameterDefinition[] parameterDefinitions, Command[] commands) : base(debugSymbol)
        {
            Name = name;
            ParameterDefinitions = parameterDefinitions;
            Commands = commands;
        }
    }
    public class ParameterDefinition : RunTimeObject
    {
        public readonly string Name;
        public readonly DataType DataType;
        public ParameterDefinition(DebugSymbol debugSymbol, string name, DataType dataType) : base(debugSymbol)
        {
            Name = name;
            DataType = dataType;
        }
    }
}