// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents an action that occurs over a period of time.
/// </summary>
[Serializable]
internal abstract class Timer : IGetKey, IIntValue, IChangeTracker
{
    protected readonly Game Game;

    /// <summary>
    /// Resets the <see cref="IsChanged"/> change tracking flag.
    /// </summary>
    public virtual void ClearChangedFlag()
    {
        IsChanged = false;
    }

    /// <summary>
    /// Returns true, if the value has changed since the last <see cref="ClearChangedFlag"/>.
    /// </summary>
    public virtual bool IsChanged { get; private set; }

    public Timer(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    private int _value;

    /// <summary>
    /// Gets or sets the number of turns remaining on the timer.
    /// </summary>
    /// <remarks>This property encapsulated the _value field.  When the actual value changes, the <see cref="IsChanged"/> property is set to true.</remarks>
    public int Value
    {
        get
        {
            return _value;
        }
        private set
        {
            if (_value  != value)
            {
                IsChanged = true;
            }
            _value = value;
        }
    }

    /// <summary>
    /// Adds (or subtracts) turns from the timer and returns true, if the action was identifiable; false, otherwise.  The action is identifiable when the timer is started or stopped.
    /// </summary>
    /// <param name="deltaValue"></param>
    /// <returns></returns>
    public bool AddTimer(int deltaValue)
    {
        return SetTimer(Value + deltaValue);
    }

    /// <summary>
    /// Converts the current timer into a rate.  Rates are ranges of values.  By default, a rate of 1 is returns for all timer values greater than 0 and a rate of 0 is returned
    /// when the timer is stopped.  Derived timers can modify these rates.
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
    /// Returns the maximum number of turns for the timer.  
    /// </summary>
    protected virtual int MaxTurns => 10000;

    public int IntValue => Value;

    /// <summary>
    /// Returns the message to be rendered when the effect transitions from above zero to zero.  This transition is noticed.
    /// </summary>
    protected abstract void EffectStopped();

    /// <summary>
    /// This event is fired when the rate is increased.
    /// </summary>
    /// <param name="newRate"></param>
    /// <param name="oldRate"></param>
    /// <returns></returns>
    protected abstract void OnRateIncreased(int newRate, int oldRate);

    /// <summary>
    /// Performs additional actions, when the effect is noticed.  The effect is only noticed when the rate transitions above or below zero.
    /// </summary>
    protected virtual void Noticed()
    {
        Game.Disturb(false);
        Game.HandleStuff();
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
            OnRateIncreased(newRate, currentRate);

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
    /// Stops the timer and returns true, if the action was noticed.  The action will be noticed, if the timer was already running.
    /// </summary>
    /// <param name="turns"></param>
    /// <returns></returns>
    public virtual bool ResetTimer() // TODO: Return IdentifiedResult
    {
        return SetTimer(0);
    }

    /// <summary>
    /// Resets the timer to a specific value.  No messages or processing occurs.  The default value of 0 allows the timer to be reset
    /// without any notice to the player.
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
