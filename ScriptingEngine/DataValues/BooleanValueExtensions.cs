
namespace Big6Search.ScriptingEngine
{

    public partial class DataValue
    {
        public bool IsBoolean()
        {
            return typeof(BooleanValue).IsAssignableFrom(GetType());
        }
        public bool IsTrue()
        {
            return IsBoolean() && ((BooleanValue)this).Value;
        }
        public bool IsFalse()
        {
            return IsBoolean() && !((BooleanValue)this).Value;
        }
    }
}