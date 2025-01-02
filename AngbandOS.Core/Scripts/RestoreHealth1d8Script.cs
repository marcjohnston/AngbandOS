// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RestoreHealth1d8Script : Script, IReadScrollAndUseStaffScript
{
    private RestoreHealth1d8Script(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedAndUsedResult ExecuteReadScrollAndUseStaffScript()
    {
        bool isIdentified = Game.RestoreHealth(Game.DieRoll(8));
        return new IdentifiedAndUsedResult(isIdentified, true);
    }
}
