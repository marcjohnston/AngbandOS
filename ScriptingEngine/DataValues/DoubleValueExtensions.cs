
namespace Big6Search.ScriptingEngine
{

    public partial class DataValue
    {
        public bool IsDouble()
        {
            return typeof(DoubleValue).IsAssignableFrom(GetType());
        }
    }
}