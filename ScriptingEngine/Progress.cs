
namespace Big6Search.ScriptingEngine
{

    public class Progress
    {
        private string _stage = null;
        public string Stage
        {
            get
            {
                return _stage;
            }
            set
            {
                _stage = value;
                OnProgressChanged();
            }
        }
        public event ProgressChangedEventHandler ProgressChanged;

        public delegate void ProgressChangedEventHandler(RunTime.WorkEnvironment workEnvironment);
        /// <summary>
    /// Fires the ProgressChanged event. This event is fired from a separate thread.
    /// </summary>
    /// <remarks></remarks>
        public virtual void OnProgressChanged()
        {
            ProgressChanged?.Invoke(WorkEnvironment);
        }
        private int _current = 0;
        public int Current
        {
            get
            {
                return _current;
            }
            set
            {
                if (value >= 0 && value <= Max)
                {
                    _current = value;
                    OnProgressChanged();
                }
            }
        }
        private int _max = 100;
        public int Max
        {
            get
            {
                return _max;
            }
            set
            {
                if (value > 0)
                {
                    _max = value;
                    OnProgressChanged();
                }
            }
        }
        public override string ToString()
        {
            return byMarc.Net2.Library.Strings.StringLib.SuffixIf(Stage, " ") + Current.ToString() + " of " + Max.ToString() + " " + (_current / (double)_max).ToString() + "%";
        }
        public readonly RunTime.WorkEnvironment WorkEnvironment;
        public Progress(RunTime.WorkEnvironment workEnvironment)
        {
            WorkEnvironment = workEnvironment;
        }
    }
}