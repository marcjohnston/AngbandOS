
namespace Big6Search.ScriptingEngine
{

    public partial class DataValue
    {
        public bool IsInteger()
        {
            return typeof(IntegerValue).IsAssignableFrom(GetType());
        }
    }
}