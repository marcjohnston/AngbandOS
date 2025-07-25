﻿
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents a widget that renders the label for the experience level in Pascal case when the player has lost one or more levels from their maximum gained
/// experience level.
/// </summary>
[Serializable]
public class ExperienceLevelLostLabelWidget : LabelWidgetGameConfiguration
{
    public override int X => 0;
    public override int Y => 5;
    public override string Text => "Level";
}
