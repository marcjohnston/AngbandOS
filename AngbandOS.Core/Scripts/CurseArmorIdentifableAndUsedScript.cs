// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CurseArmorIdentifableAndUsedScript : Script, IReadScrollAndUseStaffScript
{
    private CurseArmorIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteReadScrollAndUseStaffScript()
    {
        bool identified = Game.CurseArmor(); // An attempt to curse armor allows the action to be identified.
        return (identified, true);
    }
}

