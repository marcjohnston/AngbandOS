// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DispelUndeadAndDemonsScript : Script, IScript
{
    private DispelUndeadAndDemonsScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.DispelUndead(Game.ExperienceLevel.IntValue * 3);
        Game.DispelDemons(Game.ExperienceLevel.IntValue * 3);
    }
}
