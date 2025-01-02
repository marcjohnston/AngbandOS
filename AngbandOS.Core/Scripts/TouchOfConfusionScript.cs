// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TouchOfConfusionScript : Script, IScript, ICastSpellScript
{
    private TouchOfConfusionScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Sets the HasConfusingTouch property to true.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.HasConfusingTouch)
        {
            Game.MsgPrint("Your hands start glowing.");
            Game.HasConfusingTouch = true;
        }
    }
}
