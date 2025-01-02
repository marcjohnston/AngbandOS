// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DetonationsScript : Script, IIdentifiedScript
{
    private DetonationsScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteIdentifiedScript()
    {
        // Detonations does 50d20 damage, stuns you, and gives you a stupid amount of bleeding
        Game.MsgPrint("Massive explosions rupture your body!");
        Game.TakeHit(Game.DiceRoll(50, 20), "a potion of Detonation");
        Game.StunTimer.AddTimer(75);
        Game.BleedingTimer.AddTimer(5000);
        return new IdentifiedResult(true);
    }
}