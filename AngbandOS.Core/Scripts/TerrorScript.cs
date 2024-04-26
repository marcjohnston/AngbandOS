// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TerrorScript : Script, IScript
{
    private TerrorScript(Game game) : base(game) { }

    /// <summary>
    /// Adds fear and health damage to all monsters in a distance of 30 + the player experience.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.TurnMonsters(30 + Game.ExperienceLevel.IntValue);
    }
}
