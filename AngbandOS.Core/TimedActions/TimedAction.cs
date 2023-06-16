namespace AngbandOS.Core.TimedActions;

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

    protected int _turnsRemaining;
    public int TurnsRemaining => _turnsRemaining;

    /// <summary>
    /// Adds (or subtracts) time from the timer.
    /// </summary>
    /// <param name="deltaValue"></param>
    /// <returns></returns>
    public virtual bool AddTimer(int deltaValue)
    {
        return SetTimer(_turnsRemaining + deltaValue);
    }

    /// <summary>
    /// Converts a number of turns into a rate.  This rate is used to provide separation between grades of effects.
    /// </summary>
    /// <param name="turns"></param>
    /// <returns></returns>
    protected virtual int GetRate(int turns)
    {
        if (turns > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// Returns the maximum number of turns the effect is allowed to have.
    /// </summary>
    protected virtual int MaxTurns => 10000;

    /// <summary>
    /// Returns the message to be rendered when the effect transitions from above zero to zero.  This transition is noticed.
    /// </summary>
    protected abstract void EffectStopped();

    /// <summary>
    /// Returns the message to be rendered when the effect is increased by at least 1 rate.  This transition is not noticed.
    /// </summary>
    /// <param name="newRate"></param>
    /// <param name="oldRate"></param>
    /// <returns></returns>
    protected abstract void EffectIncreased(int newRate, int oldRate);
    /// <summary>
    /// Performs additional actions, when the effect is noticed.  The effect is only noticed when the rate transitions above or below zero.
    /// </summary>
    protected virtual void Noticed()
    {
        SaveGame.Disturb(false);
        SaveGame.HandleStuff();
    }

    /// <summary>
    /// Updates the timer associated with the action and returns true, if the action was noticed; false, otherwise.
    /// </summary>
    /// <param name="turns"></param>
    /// <returns></returns>
    public virtual bool SetTimer(int turns)
    {
        bool notice = false;
        turns = Math.Max(turns, 0);
        turns = Math.Min(turns, MaxTurns);

        int currentRate = GetRate(TurnsRemaining);
        int newRate = GetRate(turns);

        if (newRate > currentRate)
        {
            EffectIncreased(newRate, currentRate);

            // We only notice when the current rate is zero.
            notice = (currentRate == 0);
        }
        else if (newRate == 0 && currentRate > 0)
        {
            EffectStopped();
            notice = true;
        }
        _turnsRemaining = turns;
        if (!notice)
        {
            return false;
        }
        Noticed();
        return true;
    }

    public virtual bool ResetTimer()
    {
        return SetTimer(0);
    }

    /// <summary>
    /// Resets the timer to a specific value.  No messages or processing occurs.
    /// </summary>
    public virtual void SetValue(int value = 0)
    {
        _turnsRemaining = value;
    }

    public virtual void ProcessWorld()
    {
        if (TurnsRemaining > 0)
        {
            AddTimer(-1);
        }
    }
}
