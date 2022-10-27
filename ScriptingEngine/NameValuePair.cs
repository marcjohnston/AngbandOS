
namespace Big6Search.ScriptingEngine
{
    public class NameValuePair
    {
        public readonly string Name;
        public readonly RunTime.Expression Value;
        public NameValuePair(string name, RunTime.Expression value)
        {
            Name = name;
            Value = value;
        }
    }
}