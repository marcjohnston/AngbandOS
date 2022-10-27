
namespace Big6Search.ScriptingEngine
{

    public partial class DataValue
    {
        public bool IsArray()
        {
            return typeof(ArrayValue).IsAssignableFrom(GetType());
        }
    }
}