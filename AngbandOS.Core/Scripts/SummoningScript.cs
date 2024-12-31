// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummoningScript : Script, IIdentifiedAndUsedScript
{
    private SummoningScript(Game game) : base(game) { }

    public (bool identified, bool used) ExecuteIdentifiedAndUsedScript()
    {
        for (int k = 0; k < Game.DieRoll(4); k++)
        {
            if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, null))
            {
                return (true, true);
            }
        }
        return (false, true);
    }
}