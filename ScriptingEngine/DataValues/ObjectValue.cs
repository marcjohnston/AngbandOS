
namespace Big6Search.ScriptingEngine
{
    public class ObjectValue : RunTime.RunTimeObject
    {

        public readonly string ObjectName;
        /// <summary>
    /// Returns the value of the object and checks to ensure the return value is valid.
    /// </summary>
    /// <typeparam name="t"></typeparam>
    /// <param name="job"></param>
    /// <param name="canBeNothing"></param>
    /// <returns></returns>
    /// <remarks></remarks>
        public virtual DataValue GetValue<t>(RunTime.Job job, bool canBeNothing = false) where t : DataValue
        {
            var dataValue = GetValue(job);

            // Check to see if the value datatype is valid.
            // Check to see if nothing is not allowed and that the value is nothing or if the value isn't nothing, that it is the correct data type.
            if (!canBeNothing && dataValue == null || !(dataValue == null) && !typeof(t).IsAssignableFrom(dataValue.GetType()))
            {
                throw new RunTimeErrorScriptException("Invalid object.");
            }
            return dataValue;
        }
        public override ScriptTreeNode ToTreeNode()
        {
            return new ScriptTreeNode(this, ObjectName);
        }
        public override object ToText()
        {
            return ObjectName;
        }
        public virtual DataValue GetValue(RunTime.Job job)
        {
            RunTime.ObjectSymbol symbol = (RunTime.ObjectSymbol)job.WorkEnvironment.GetSymbol(ObjectName);
            return symbol.Value;
        }
        public virtual void SetValue(RunTime.Job job, DataValue value)
        {
            RunTime.ObjectSymbol symbol = (RunTime.ObjectSymbol)job.WorkEnvironment.GetSymbol(ObjectName);
            symbol.Value = value;
        }
        public ObjectValue(string objectName) : this(null, objectName)
        {
        }
        public ObjectValue(DebugSymbol debugSymbol, string objectName) : base(debugSymbol)
        {
            ObjectName = objectName;
        }
    }
}