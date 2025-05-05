// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

/// <summary>
/// Represents a widget that renders a single line of text at the coordinates specified by <see cref="X"/> and <see cref="Y"/>.  Text is automatically justified using the <see cref="Justification"/>
/// property within the space provided by the <see cref="Width"/> property.  The text is drawn in the color specified by the <see cref="Color"/> property.
/// </summary>
[Serializable]
internal abstract class TextWidget : Widget
{
    protected TextWidget(Game game) : base(game) { }

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
    public virtual int? Width => null;

    /// <summary>
    /// Returns the <see cref="Justification"/> object to be used to justify the text within the <see cref="Width"/> of the <see cref="TextWidget"/>.  This property is bound using
    /// the <see cref="JustificationName"/> property during the bind phase.
    /// </summary>
    protected Justification Justification { get; private set; }

    /// <summary>
    /// Returns the name of the <see cref="Justification"/> object to be used to justify the text within the <see cref="Width"/> of the <see cref="TextWidget" />.  This property
    /// is used to bind the <see cref="Justification"/> property.  Defaults to <see cref="LeftJustification"/>.
    /// </summary>
    public virtual string JustificationName => nameof(LeftJustification);

    public override void Bind()
    {
        base.Bind();
        Justification = Game.SingletonRepository.Get<Justification>(JustificationName);
    }

    /// <summary>
    /// Paint the widget on the screen.  No checks or resets of the validation status are or should be performed during this method.
    /// </summary>
    protected override void Paint()
    {
        string justifiedText = Text;
        justifiedText = Justification.Format(justifiedText, Width ?? justifiedText.Length);
        Game.Screen.Print(Color, justifiedText, Y, X);
    }
}
