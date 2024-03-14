// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Timers;

/// <summary>
/// Represents an action that occurs over a period of time.
/// </summary>
[Serializable]
internal abstract class Timer : IGetKey<string>, IIntChangeTrackable
{
    protected SaveGame SaveGame { get; }

    public virtual void ClearChangedFlag()
    {
        IsChanged = false;
    }

    public virtual bool IsChanged { get; private set; }

    public Timer(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    private int _value;

    /// <summary>
    /// Gets or sets the number of turns remaining on the timer.
    /// </summary>
    public int Value
    {
        get
        {
            return _value;
        }
        private set
        {
            // TODO: There is no detection that the value actually changed to detect the change and _changed = true.
            _value = value;
            IsChanged = true;
        }
    }

    /// <summary>
    /// Adds (or subtracts) time from the timer and returns true, if the action was noticed.  The action is noticed, if the timer was stopped.  The action is not
    /// noticed, if the timer was already running.
    /// </summary>
    /// <param name="deltaValue"></param>
    /// <returns></returns>
    public bool AddTimer(int deltaValue)
    {
        return SetTimer(Value + deltaValue);
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
    /// Updates the timer with a specific value and returns true, if the action was noticed; false, otherwise.  The action is noticed when the timer is started
    /// or stopped.  The action is not noticed when time is added to a running timer or time is subtracted from a running timer that does not result stopping the timer.
    /// </summary>
    /// <param name="turns"></param>
    /// <returns></returns>
    public virtual bool SetTimer(int turns)
    {
        bool notice = false;
        turns = Math.Max(turns, 0);
        turns = Math.Min(turns, MaxTurns);

        int currentRate = GetRate(Value);
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
        Value = turns;
        if (!notice)
        {
            return false;
        }
        Noticed();
        return true;
    }

    /// <summary>
    /// Stops the timer associated with the action and returns true, if the action was noticed.  The action will be noticed, if the timer was running.  The action 
    /// will not be noticed if the timer was already stopped.
    /// </summary>
    /// <param name="turns"></param>
    /// <returns></returns>
    public virtual bool ResetTimer()
    {
        return SetTimer(0);
    }

    /// <summary>
    /// Resets the timer to a specific value.  No messages or processing occurs.
    /// </summary>
    public virtual void SetValue(int value = 0)
    {
        Value = value;
    }

    public virtual void ProcessWorld()
    {
        if (Value > 0)
        {
            AddTimer(-1);
        }
    }
}
