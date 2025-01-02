// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EaglesVisionScript : Script, IScript, ICastSpellScript
{
    private EaglesVisionScript(Game game) : base(game) { }


    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Detects traps, doors and stairs.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.DetectTraps();
        Game.DetectDoors();
        Game.DetectStairs();
    }
}
