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
    private GainExpReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
        SaveGame.MsgPrint("'Well done, mortal! Lead on!'");
        if (SaveGame.ExperiencePoints < Constants.PyMaxExp)
        {
            int ee = (SaveGame.ExperiencePoints / 2) + 10;
            if (ee > 100000)
            {
                ee = 100000;
            }
            SaveGame.MsgPrint("You feel more experienced.");
            SaveGame.GainExperience(ee);
        }
    }
}