// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class LoseMemoriesScript : Script, IEatOrQuaffScript
{
    private LoseMemoriesScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResultEnum ExecuteEatOrQuaffScript()
    {
        // Lose Memories reduces your experience
        if (!Game.HasHoldLife && Game.ExperiencePoints.IntValue > 0)
        {
            Game.MsgPrint("You feel your memories fade.");
            Game.LoseExperience(Game.ExperiencePoints.IntValue / 4);
            return IdentifiedResultEnum.True;
        }
        return IdentifiedResultEnum.False;
    }
}