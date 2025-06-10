
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Represents a widget that renders the Mana label.
/// </summary>
[Serializable]
public class ManaLabelTextWidget : TextWidgetGameConfiguration
{
    public override int X => 0;
    public override int Y => 26;
    public override string Text => "Cur SP";
}

