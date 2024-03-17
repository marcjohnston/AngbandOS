// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Diagnostics;

namespace AngbandOS.Core.Widgets;

[Serializable]
internal abstract class Widget : IGetKey<string>
{
    protected readonly SaveGame SaveGame;
    protected Widget(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// Returns true, if the widget is invalid and needs to be redrawn.
    /// </summary>
    public bool Invalidated { get; private set; }

    /// <summary>
    /// Invalidates the widget.  An invalidated widget will call the <see cref="Paint"/> method, when the <see cref="Update"/> method is called.
    /// </summary>
    public void Invalidate()
    {
        Invalidated = true;
    }

    /// <summary>
    /// Returns an array of conditionals that need to be met for the widget to rendered; or null, if there are no conditions.  All conditions must return true for the widget
    /// to be enabled.
    /// </summary>
    public (Conditional conditional, bool isTrue)[]? Enabled { get; private set; }

    public virtual (string conditionalName, bool isTrue)[]? EnabledConditionalNames => null;

    /// <summary>
    /// Returns the text to be rendered for the widget.
    /// </summary>
    public abstract string Text { get; }

    /// <summary>
    /// Returns the color that the widget <see cref="Text"/> will be drawn.  Returns the color white by default.
    /// </summary>
    public virtual ColorEnum Color => ColorEnum.White;

    /// <summary>
    /// Returns the x-coordinate on the <see cref="Form"/> where the widget will be drawn.
    /// </summary>
    public abstract int X { get; }

    /// <summary>
    /// Returns the y-coordinate on the <see cref="Form"/> where the widget will be drawn.
    /// </summary>
    public abstract int Y { get; }

    /// <summary>
    /// Returns the width of the widget.  A width that is equal to the length of the <see cref="Text"/> property is returned by default.
    /// </summary>
    public virtual int Width => Text.Length;

    /// <summary>
    /// Returns the height of the widget.  A height of 1 is returned by default.
    /// </summary>
    public virtual int Height => 1;

    /// <summary>
    /// Returns the <see cref="Justification"/> object to be used to justify the text within the <see cref="Width"/> of the <see cref="Widget"/>.  This property is bound using
    /// the <see cref="JustificationName"/> property during the bind phase.
    /// </summary>
    protected Justification? Justification { get; private set; }

    /// <summary>
    /// Returns the name of the <see cref="Justification"/> object to be used to justify the text within the <see cref="Width"/> of the <see cref="Widget" />.  This property
    /// is used to bind the <see cref="Justification"/> property.
    /// </summary>
    public virtual string? JustificationName => nameof(LeftJustification);
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public virtual void Bind()
    {
        Justification = JustificationName == null ? null : SaveGame.SingletonRepository.Justifications.Get(JustificationName);

        if (EnabledConditionalNames == null)
        {
            Enabled = null;
        }
        else
        {
            List<(Conditional, bool)> conditionalList = new();
            foreach ((string conditionalName, bool isTrue) in EnabledConditionalNames)
            {
                conditionalList.Add((SaveGame.SingletonRepository.Conditionals.Get(conditionalName), isTrue));
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
    protected virtual void Paint()
    {
        string justifiedText = Text;
        if (Justification != null)
        {
            justifiedText = Justification.Format(justifiedText, Width);
        }
        SaveGame.Screen.Print(Color, justifiedText, Y, X);
    }

    /// <summary>
    /// Update the widget on the screen, if the widget needs to be redrawn.  The widget will be redrawn, if the widget was invalidated or the derived widget returns true
    /// on the QueryRedraw method.
    /// </summary>
    public virtual void Update()
    {
        // Check to see if the widget is enabled.  All conditionals must be true.
        if (Enabled != null && Enabled.Any(_conditions => _conditions.conditional.IsTrue != _conditions.isTrue))
        {
            return;
        }

        if (Invalidated)
        {
            Paint();

            // Now that the widget has been draw, validate it.
            Invalidated = false;
        }
    }
}
