
namespace Big6Search.ScriptingEngine.RunTime
{
    public abstract partial class Symbol
    {
        public readonly string Name;
        public Symbol(string name)
        {
            Name = name;
        }
    }
}