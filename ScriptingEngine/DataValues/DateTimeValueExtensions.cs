
namespace Big6Search.ScriptingEngine
{

    public partial class DataValue
    {
        public bool IsDateTime()
        {
            return typeof(DateTimeValue).IsAssignableFrom(GetType());
        }
    }
}