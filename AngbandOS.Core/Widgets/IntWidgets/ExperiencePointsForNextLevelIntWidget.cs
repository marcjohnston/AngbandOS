﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Widgets;

/// <summary>
/// Represents a widget that renders the experience points that are needed for the player to gain the next level.
/// </summary>
[Serializable]
internal class ExperiencePointsForNextLevelIntWidget : IntTextWidget
{
    private ExperiencePointsForNextLevelIntWidget(Game game) : base(game) { } // This object is a singleton.
    public override int X => 4;
    public override int Y => 6;
    public override int Width => 8;
    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string IntValueName => nameof(ExperiencePointsForNextLevelFunction);
    public override string JustificationName => nameof(RightJustification);
}