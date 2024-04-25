// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

/// <summary>
/// Represents an on-screen widget that renders game data.  Widgets are invalidated when they need to be updated.  The Update method determines whether or not the widget
/// needs to be updated and the Paint method is used to actually draw the widget.  
/// </summary>
[Serializable]
internal abstract class Widget : IGetKey
{
    protected readonly Game Game;
    protected Widget(Game game)
    {
        Game = game;
    }

    public virtual bool CanPoke => false;

    /// <summary>
    /// Locate the cursor in the viewport at a specific level grid x, y coordinate.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    public virtual void MoveCursorTo(int row, int col) { }

    public virtual void Poke(ColorEnum attr, char ch, int row, int col) {}

    /// <summary>
    /// Returns true, if the widget is invalid and needs to be redrawn.
    /// </summary>
    public bool IsInvalid { get; private set; } = true;

    /// <summary>
    /// Invalidates the widget.  An invalidated widget will call the <see cref="Paint"/> method, when the <see cref="Update"/> method is called.
    /// </summary>
    public void Invalidate()
    {
        IsInvalid = true;
    }

    /// <summary>
    /// Returns an array of conditionals that need to be met for the widget to rendered; or null, if there are no conditions.  All conditions must return true for the widget
    /// to be enabled.
    /// </summary>
    [Obsolete("Use ConditionalWidget")]
    public (IBoolValue conditional, bool isTrue)[]? Enabled { get; private set; }

    [Obsolete("Use ConditionalWidget")]
    public virtual (string conditionalName, bool isTrue)[]? EnabledNames => null;

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public virtual void Bind()
    {
        if (EnabledNames == null)
        {
            Enabled = null;
        }
        else
        {
            List<(IBoolValue, bool)> conditionalList = new();
            foreach ((string enabledName, bool isTrue) in EnabledNames)
            {
                Property? property = Game.SingletonRepository.Properties.TryGet(enabledName);
                if (property != null)
                {
                    conditionalList.Add(((IBoolValue)property, isTrue));
                } 
                else
                { 
                    Function? function = Game.SingletonRepository.Functions.TryGet(enabledName);
                    if (function == null)
                    {
                        throw new Exception($"The {enabledName} enabled dependency cannot be found as a {nameof(Property)} or {nameof(Function)}.");
                    }
                    conditionalList.Add(((IBoolValue)function, isTrue));
                }
            }
            Enabled = conditionalList.ToArray();
        }
    }

    public string ToJson()
    {
        return "";
    }

    /// <summary>
    /// Paint the widget on the screen.  No checks or resets of the validation status are or should be performed during this method.
    /// </summary>
    protected abstract void Paint();

    /// <summary>
    /// Update the widget on the screen, if the widget needs to be redrawn.  The widget will be redrawn, if the widget was invalidated or the derived widget returns true
    /// on the QueryRedraw method.
    /// </summary>
    public virtual void Update()
    {
        // Check to see if the widget is enabled.  All conditionals must be true.
        if (Enabled != null && Enabled.Any(_conditions => _conditions.conditional.BoolValue != _conditions.isTrue))
        {
            return;
        }

        if (IsInvalid)
        {
            Paint();

            // Now that the widget has been draw, validate it.
            IsInvalid = false;
        }
    }
}
