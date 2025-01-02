// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonMonsterIdentifableAndUsedScript : Script, IReadScrollOrUseStaffScript
{
    private SummonMonsterIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        bool isIdentified = false;
        for (int i = 0; i < Game.DieRoll(3); i++)
        {
            if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, null, true, false))
            {
                isIdentified = true;
            }
        }
        return new IdentifiedAndUsedResult(isIdentified, true);
    }
}

