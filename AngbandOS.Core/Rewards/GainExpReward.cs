// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Rewards;

[Serializable]
internal class GainExpReward : Reward
{
    private GainExpReward(Game game) : base(game) { }
    public override void GetReward(Patron patron)
    {
        Game.MsgPrint($"The voice of {patron.ShortName} booms out:");
        Game.MsgPrint("'Well done, mortal! Lead on!'");
        if (Game.ExperiencePoints.Value < Constants.PyMaxExp)
        {
            int ee = (Game.ExperiencePoints.Value / 2) + 10;
            if (ee > 100000)
            {
                ee = 100000;
            }
            Game.MsgPrint("You feel more experienced.");
            Game.GainExperience(ee);
        }
    }
}