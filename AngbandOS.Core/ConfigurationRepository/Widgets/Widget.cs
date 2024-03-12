// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

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
    /// Returns true, when the widget has been invalidated.
    /// </summary>
    public bool Invalidated { get; private set; }

    /// <summary>
    /// Invalidates the widget.
    /// </summary>
    public void Invalidate()
    {
        Invalidated = true;
    }

    /// <summary>
    /// Returns true, if the widget needs to be redrawn.
    /// </summary>
    protected virtual bool QueryRedraw { get; }

    public abstract string Text { get; }
    public abstract ColorEnum Color { get; }
    public abstract int X { get; }
    public abstract int Y { get; }
    public virtual int Width => Text.Length;
    public virtual int Height => 1;

    protected Justification? Justification { get; private set; }
    public virtual string? JustificationName => nameof(LeftJustification);
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public virtual void Bind()
    {
        Justification = JustificationName == null ? null : SaveGame.SingletonRepository.Justifications.Get(JustificationName);
    }

    public string ToJson()
    {
        return "";
    }

    /// <summary>
    /// Redraws the widget.  The widget has been deemed invalid via the <see cref="Invalidated"/> == true or the dervied object returned true on the <see cref="QueryRedraw"/> method.
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
        if (Invalidated)
        {
            Paint();
            Invalidated = false;
        }
    }
}
