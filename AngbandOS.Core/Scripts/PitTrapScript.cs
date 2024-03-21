// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PitTrapScript : Script, IScript
{
    private PitTrapScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // A pit can be flown over with feather fall
        if (Game.HasFeatherFall)
        {
            Game.MsgPrint("You fly over a pit trap.");
        }
        else
        {
            Game.MsgPrint("You fell into a pit!");
            // Pits do 2d6 fall damage
            int damage = Game.DiceRoll(2, 6);
            string name = "a pit trap";
            Game.TakeHit(damage, name);
        }
    }
}
