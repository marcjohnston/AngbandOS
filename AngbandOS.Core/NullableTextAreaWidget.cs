// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class NullableTextAreaWidget : TextAreaWidget
{
    protected NullableTextAreaWidget(Game game) : base(game) { }

    /// <summary>
    /// Returns the text to be rendered for the widget.
    /// </summary>
    public abstract string[]? NullableText { get; }

    public override string[] Text => NullableText ?? NullText;

    /// <summary>
    /// Returns the text to render when the value is null.  By default, returns a single line of an empty string.  The alignment will vertically add lines and the justification
    /// will horizontally add space.
    /// </summary>
    public virtual string[] NullText => new string[] { String.Empty };
}
