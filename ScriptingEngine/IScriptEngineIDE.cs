
namespace Big6Search.ScriptingEngine
{
    public interface IScriptEngineIDE
    {
        void Compile();
        RunTime.Job CurrentJob();
        ScriptEngine ScriptEngine();
        event CurrentJobChangedEventHandler CurrentJobChanged;

        delegate void CurrentJobChangedEventHandler(RunTime.Job job);
    }
}