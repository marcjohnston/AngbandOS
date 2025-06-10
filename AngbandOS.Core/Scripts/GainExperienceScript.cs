// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class GainExperienceScript : Script, IEatOrQuaffScript
{
    private GainExperienceScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        // Experience increases your experience points by 50%, with a minimum of +10 and
        // maximuum of +10,000
        if (Game.ExperiencePoints.IntValue < Constants.PyMaxExp)
        {
            int ee = (Game.ExperiencePoints.IntValue / 2) + 10;
            if (ee > 100000)
            {
                ee = 100000;
            }
            Game.MsgPrint("You feel more experienced.");
            Game.GainExperience(ee);
            return new IdentifiedResult(true);
        }
        return new IdentifiedResult(false);
    }
}