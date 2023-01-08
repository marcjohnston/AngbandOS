namespace AngbandOS.Core.TimedActions
{
    /// <summary>
    /// Represents an action that occurs over a period of time.
    /// </summary>
    [Serializable]
    internal abstract class TimedAction
    {
        protected SaveGame SaveGame { get; }

        public TimedAction(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }

        protected int _timer;
        public int TimeRemaining => _timer;

        /// <summary>
        /// Updates the timer associated with the action and returns true, if the action was noticed; false, otherwise.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool SetTimer(int value);

        /// <summary>
        /// Resets the timer to a specific value.  No messages or processing occurs.
        /// </summary>
        public virtual void Reset(int value = 0)
        {
            _timer = value;
        }

        public virtual void ProcessWorld()
        {
            if (TimeRemaining > 0)
            {
                SetTimer(_timer - 1);
            }
        }
    }
}
