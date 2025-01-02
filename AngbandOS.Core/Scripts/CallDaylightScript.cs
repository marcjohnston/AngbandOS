// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CallDaylightScript : Script, IScript, ICastSpellScript
{
    private CallDaylightScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.RunScript(nameof(LightAreaScript));
        if (!Game.Race.IsBurnedBySunlight || Game.HasLightResistance)
        {
            return;
        }
        Game.MsgPrint("The daylight scorches your flesh!");
        Game.TakeHit(Game.DiceRoll(2, 2), "daylight");
    }
}
