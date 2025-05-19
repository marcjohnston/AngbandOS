// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

/// <summary>
/// Use a rod from the inventory or ground
/// </summary>
/// <param name="itemIndex"> The inventory index of the item to be used </param>
[Serializable]
public class ZapRodGameCommand : GameCommandGameConfiguration
{
    public override char KeyChar => 'z';

    public override string? ExecuteScriptName => nameof(SystemScriptsEnum.ZapRodScript);
}
