// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Use a staff from the inventory or floor
/// </summary>
/// <param name="itemIndex"> The inventory index of the item to use </param>
[Serializable]
public class UseStaffGameCommand : GameCommandGameConfiguration
{
    public override char KeyChar => 'u';

    public override string? ExecuteScriptName => nameof(SystemScriptsEnum.UseStaffScript);
}
