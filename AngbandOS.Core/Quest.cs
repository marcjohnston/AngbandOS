// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class Quest
{
    public bool Discovered;
    public Dungeon Dungeon;
    public int Killed;

    /// <summary>
    /// Returns 0, when the level is complete, otherwise, returns the level at which the guardian is at.
    /// </summary>
    public int Level;
    public int RIdx;
    public int ToKill;
    protected readonly SaveGame SaveGame;

    public bool IsActive => (Level != 0 && Killed < ToKill);

    /// <summary>
    /// Returns a single line description of the quest.  This description is rendered in the Journal Quests.
    /// </summary>
    /// <returns></returns>
    public string Describe()
    {
        string buf;
        MonsterRace rPtr = SaveGame.SingletonRepository.MonsterRaces[RIdx];
        string name = rPtr.Name;
        int qNum = ToKill;
        string dunName = Dungeon.Name;
        int lev = Level;
        if (Level == 0)
        {
            if (qNum == 1)
            {
                buf = $"You have defeated {name} in {dunName}";
            }
            else
            {
                string plural = name.PluralizeMonsterName();
                buf = $"You have defeated {qNum} {plural} in {dunName}";
            }
        }
        else
        {
            if (Discovered)
            {
                if (qNum == 1)
                {
                    buf = $"You must defeat {name} at lvl {lev} of {dunName}";
                }
                else
                {
                    if (ToKill - Killed > 1)
                    {
                        string plural = name.PluralizeMonsterName();
                        buf = $"You must defeat {qNum} {plural} at lvl {lev} of {dunName}";
                    }
                    else
                    {
                        buf = $"You must defeat 1 {name} at lvl {lev} of {dunName}";
                    }
                }
            }
            else
            {
                buf = $"You must defeat something at lvl {lev} of {dunName}";
            }
        }
        return buf;
    }

    public Quest(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }
}