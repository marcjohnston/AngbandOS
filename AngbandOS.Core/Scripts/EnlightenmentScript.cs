// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EnlightenmentScript : Script, IEatOrQuaffScript
{
    private EnlightenmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        // Enlightenment shows you the whole level
        Game.MsgPrint("An image of your surroundings forms in your mind...");
        Game.RunScript(nameof(LightScript));
        return new IdentifiedResult(true);
    }
}