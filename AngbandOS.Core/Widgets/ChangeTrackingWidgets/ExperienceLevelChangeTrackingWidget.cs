// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

/// <summary>
/// Represents a change tracking widget used to render the ExperienceLevel value and label widgets when the experience level changes.  This is the first widget in 
/// the chain and detects when the <see cref="ExperienceLevelIntProperty"/> property has changed before rendering the child <see cref="ExperienceLevelConditionalWidget"/> widget.
/// </summary>
[Serializable]
internal class ExperienceLevelChangeTrackingWidget : ChangeTrackingWidget
{
    private ExperienceLevelChangeTrackingWidget(Game game) : base(game) { } // This object is a singleton.
    public override string[] WidgetNames => new string[] { nameof(ExperienceLevelConditionalWidget) };
    public override string ChangeTrackingName => nameof(ExperienceLevelIntProperty);
}
