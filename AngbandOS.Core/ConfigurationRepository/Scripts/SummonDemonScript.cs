// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonDemonScript : Script, IScript
{
    private SummonDemonScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (SaveGame.Rng.DieRoll(3) == 1)
        {
            if (SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel * 3 / 2, new DemonMonsterSelector()))
            {
                SaveGame.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                SaveGame.MsgPrint("'NON SERVIAM! Wretch! I shall feast on thy mortal soul!'");
            }
            else
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
        else
        {
            if (SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel * 3 / 2, new DemonMonsterSelector(), SaveGame.ExperienceLevel == 50))
            {
                SaveGame.MsgPrint("The area fills with a stench of sulphur and brimstone.");
                SaveGame.MsgPrint("'What is thy bidding... Master?'");
            }
            else
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
    }
}
