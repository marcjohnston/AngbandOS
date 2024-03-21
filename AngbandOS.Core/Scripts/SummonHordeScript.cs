// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonHordeScript : Script, IScript
{
    private SummonHordeScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int wy = Game.MapY, wx = Game.MapX;
        int attempts = 1000;
        while (--attempts != 0)
        {
            Game.Scatter(out wy, out wx, Game.MapY, Game.MapX, 3);
            if (Game.GridOpenNoItemOrCreature(wy, wx))
            {
                break;
            }
        }
        Game.AllocHorde(wy, wx);
    }
}
