
namespace Big6Search.ScriptingEngine
{

    public partial class DataValue
    {
        public bool IsString()
        {
            return typeof(StringValue).IsAssignableFrom(GetType());
        }
    }
}