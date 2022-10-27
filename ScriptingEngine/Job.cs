using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Big6Search.ScriptingEngine.RunTime
{
    #region Job - Represents a runtime job.  Runtime jobs include the commands to be executed, the work environment and current execution details.
    /// <summary>
    /// Represents a runtime job.  Runtime jobs include the commands to be executed, the work environment and current execution details.
    /// </summary>
    /// <remarks></remarks>
    public class Job
    {

        #region Private, Protected & Friends
        #region BackgroundWorker Routines
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Main-thread.
        /// </remarks>
        private void _backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Message?.Invoke(this, new JobShutdown());
            foreach (AddIn addIn in ScriptEngine.InstalledAddIns)
                addIn.OnJobStopped(this);
        }
        private System.ComponentModel.BackgroundWorker __backgroundWorker;

        private System.ComponentModel.BackgroundWorker _backgroundWorker
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return __backgroundWorker;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (__backgroundWorker != null)
                {
                    __backgroundWorker.RunWorkerCompleted -= _backgroundWorker_RunWorkerCompleted;
                    __backgroundWorker.DoWork -= _backgroundWorker_DoWork;
                    __backgroundWorker.ProgressChanged -= _backgroundWorker_ProgressChanged;
                }

                __backgroundWorker = value;
                if (__backgroundWorker != null)
                {
                    __backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
                    __backgroundWorker.DoWork += _backgroundWorker_DoWork;
                    __backgroundWorker.ProgressChanged += _backgroundWorker_ProgressChanged;
                }
            }
        }
        private ManualResetEvent _runEvent = new ManualResetEvent(true);
        private bool _debugMode = true; // Set to true to have unhandled exceptions thrown instead of caught.
        private bool _stepMode = false; // If the _stepMode is TRUE, then the _stepEvent autoresetevent will be waited on.
        private AutoResetEvent _stepEvent = new AutoResetEvent(false);
        private void _backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Command[] commands = (Command[])e.Argument((object)0);
            WorkEnvironment workEnvironment = (WorkEnvironment)e.Argument((object)1);
            try
            {
                foreach (Command command in commands)
                {
                    command.Execute(this, workEnvironment);

                    if (StopJobPending)
                    {
                        break;
                    }
                }

                // Report the progress to the main thread.
                ReportProgress(BackgroundWorkerProgressEventsEnum.ScriptComplete, new object());
            }
            catch (RunTimeErrorScriptException ex)
            {
                // Report the progress to the main thread.
                ReportProgress(BackgroundWorkerProgressEventsEnum.RuntimeError, new object[] { ex });
            }
            catch (Exception ex) when (!_debugMode)
            {
                // Report the progress to the main thread.
                ReportProgress(BackgroundWorkerProgressEventsEnum.UnhandledException, new object[] { workEnvironment, ex });
            }
        }
        private AutoResetEvent ReportProgressWaitEvent = new AutoResetEvent(false);
        private ManualResetEvent ReportProgressReadyWaitEvent = new ManualResetEvent(false);
        private void ReportProgress(BackgroundWorkerProgressEventsEnum backgroundWorkerProgressEvents, object userState)
        {
            ReportProgressReadyWaitEvent.Reset();
            _backgroundWorker.ReportProgress((int)backgroundWorkerProgressEvents, userState);
            WaitHandle.SignalAndWait(ReportProgressReadyWaitEvent, ReportProgressWaitEvent);
        }
        private void _backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            switch ((BackgroundWorkerProgressEventsEnum)e.ProgressPercentage)
            {
                case BackgroundWorkerProgressEventsEnum.ScriptComplete:
                    {
                        Message?.Invoke(this, new ScriptCompleteMessage());
                        break;
                    }
                case BackgroundWorkerProgressEventsEnum.MarshalToMainThread:
                    {
                        InvokeRoutine routine = (InvokeRoutine)e.UserState((object)0);
                        routine((object[])e.UserState((object)1));
                        break;
                    }
                case BackgroundWorkerProgressEventsEnum.RuntimeError:
                    {
                        RunTimeErrorScriptException ex = (RunTimeErrorScriptException)e.UserState((object)0);
                        Message?.Invoke(this, new RunTimeError(ex));
                        break;
                    }
                case BackgroundWorkerProgressEventsEnum.UnhandledException:
                    {
                        Exception ex = (Exception)e.UserState((object)1);
                        Message?.Invoke(this, new UnhandledException(ex));
                        break;
                    }
                case BackgroundWorkerProgressEventsEnum.Message:
                    {
                        Message?.Invoke(this, (JobMessage)e.UserState((object)0));
                        break;
                    }
                case BackgroundWorkerProgressEventsEnum.Invoke:
                    {
                        try
                        {
                            InvokeRoutine delegateRoutine = (InvokeRoutine)e.UserState((object)0);
                            object[] args = (object[])e.UserState((object)1);
                            delegateRoutine(args);
                        }
                        catch (Exception ex)
                        {
                            Message?.Invoke(this, new UnhandledException(ex));
                        }

                        break;
                    }
            }
            ReportProgressReadyWaitEvent.WaitOne();
            ReportProgressWaitEvent.Set();
        }
        public delegate void InvokeRoutine(object[] args);
        public void MarhsalToMainThread(InvokeRoutine invokeRoutine, object[] args)
        {
            ReportProgress(BackgroundWorkerProgressEventsEnum.MarshalToMainThread, new object[] { invokeRoutine, args });
        }
        #endregion
        private void StartIfNeeded()
        {
            if (!IsRunning())
            {
                // Perform preexecute initialization.
                Message?.Invoke(this, new JobStartup());
                foreach (AddIn addIn in ScriptEngine.InstalledAddIns)
                    addIn.OnBeforeJobStart(this);
                _stepEvent.Reset();
                WorkEnvironment.Clear();
                _backgroundWorker.RunWorkerAsync(new object[] { Commands, WorkEnvironment });
            }
        }
        #endregion

        #region Public Events
        public event MessageEventHandler Message;

        public delegate void MessageEventHandler(Job job, JobMessage message);
        #endregion

        #region Public Properties
        public readonly ScriptEngine ScriptEngine;
        public readonly Command[] Commands;
        public readonly WorkEnvironment WorkEnvironment;
        public readonly object Data;
        public readonly string Script;
        public bool StopJobPending
        {
            get
            {
                return _backgroundWorker.CancellationPending;
            }
        }
        #endregion

        #region Public Methods
        public void Invoke(InvokeRoutine invokeRoutine, object[] args)
        {
            ReportProgress(BackgroundWorkerProgressEventsEnum.Invoke, new object[] { invokeRoutine, args });
        }
        public void ProcessPreCommand()
        {
            _runEvent.WaitOne();
            if (_stepMode)
            {
                _stepEvent.WaitOne();
            }
        }
        public bool IsRunning()
        {
            return _backgroundWorker.IsBusy;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Thread-safe.
        /// </remarks>
        public void Stop()
        {
            _backgroundWorker.CancelAsync();
        }
        public void Step()
        {
            _stepMode = true;
            _stepEvent.Set();

            StartIfNeeded();
        }
        public void Pause()
        {
            _stepMode = true;
            _stepEvent.Reset();
        }
        public void RaiseMessage(JobMessage message)
        {
            ReportProgress(BackgroundWorkerProgressEventsEnum.Message, new object[] { message });
        }
        // Public Overridable Sub OnBeforeExecute()
        // RaiseEvent BeforeExecute()
        // End Sub
        #region Run - Executes the job asynchronously.
        /// <summary>
        /// Executes the job asynchronously.
        /// </summary>
        /// <remarks></remarks>
        public void Run()
        {
            // Disable the step mode.
            _stepMode = false;

            // Release the thread if it is paused.
            _runEvent.Set();

            // Release the thread if it is waiting on the step.
            _stepEvent.Set();

            // Start the thread if it is not running.
            StartIfNeeded();
        }
        #endregion
        #endregion

        #region Public Constructors
        public Job(ScriptEngine scriptEngine, string script, Command[] commands, object data)
        {
            ScriptEngine = scriptEngine;
            Commands = commands;
            WorkEnvironment = new WorkEnvironment();
            Data = data;
            Script = script;

            _backgroundWorker = new System.ComponentModel.BackgroundWorker();
            {
                var withBlock = _backgroundWorker;
                withBlock.WorkerReportsProgress = true;
                withBlock.WorkerSupportsCancellation = true;
            }
        }
        #endregion

    }
    #endregion
}