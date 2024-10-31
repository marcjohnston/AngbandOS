// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class DungeonGuardianGameConfiguration
{
    public virtual string Key { get; set; }

    /// <summary>
    /// Returns the name of the race for the first quest monster.
    /// </summary>
    public virtual string MonsterRaceName { get; set; }

    /// <summary>
    /// The level for the fixed quest.
    /// </summary>
    public virtual int LevelFound { get; set; }

    //public bool IsValid()
    //{
    //    if (Key == null || MonsterRaceName == null || LevelFound == null)
    //    {
    //        return false;
    //    }
    //    return true;
    //}
}