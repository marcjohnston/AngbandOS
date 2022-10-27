
namespace Big6Search.ScriptingEngine.RunTime
{
    public class ObjectValueExpression : Expression
    {

        public readonly ObjectValue DataValueResolver;
        protected override DataValue DoCompute(Job job)
        {
            var dataValue = DataValueResolver.GetValue(job);
            return dataValue;
        }
        public ObjectValueExpression(ObjectValue dataValueResolver) : this(null, dataValueResolver)
        {
        }
        public ObjectValueExpression(DebugSymbol debugSymbol, ObjectValue dataValueResolver) : base(debugSymbol)
        {
            DataValueResolver = dataValueResolver;
        }
    }
}