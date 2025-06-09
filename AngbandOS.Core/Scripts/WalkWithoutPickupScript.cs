// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WalkWithoutPickupScript : Script, IScript, ICastSpellScript, IGameCommandScript
{
    private WalkWithoutPickupScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the stay script and disposes of the repeatable result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the stay script.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        bool isRepeatable = false;
        // If we don't already have a direction, get one
        if (Game.GetDirectionNoAim(out int dir))
        {
            // Walking takes a full turn
            Game.EnergyUse = 100;
            Game.MovePlayer(dir, true);
            isRepeatable = true;
        }
        return new RepeatableResult(isRepeatable);
    }
}
