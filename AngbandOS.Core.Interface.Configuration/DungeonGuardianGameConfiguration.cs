// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class DungeonGuardianGameConfiguration : NonCompositeSingletonGameConfiguration
{
    /// <summary>
    /// Returns the name of the race for the first quest monster.
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Monster Race Name",
        Summary = "The name of the monster race for the quest monster.",
        DataType = "string")]
    public virtual string MonsterRaceName { get; set; }

    /// <summary>
    /// The level for the fixed quest.
    /// </summary>
    [ConfigurationMetadataAttribute(
        Title = "Level Found",
        Summary = "The dungeon level where the fixed quest is encountered.",
        DataType = "int")]
    public virtual int LevelFound { get; set; }
}