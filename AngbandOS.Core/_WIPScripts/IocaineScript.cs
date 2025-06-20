// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class IocaineScript : Script, IEatOrQuaffScript
{
    private IocaineScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        // Iocaine simply does 5000 damage
        Game.MsgPrint("A feeling of Death flows through your body.");
        Game.TakeHit(5000, "a potion of Death");
        return new IdentifiedResult(true);
    }
}