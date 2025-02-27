// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class GenericDungeonGuardian : DungeonGuardian
{
    public GenericDungeonGuardian(Game game, DungeonGuardianGameConfiguration dungeonGuardianGameConfiguration) : base(game)
    {
        Key = dungeonGuardianGameConfiguration.Key ?? dungeonGuardianGameConfiguration.GetType().Name;
        MonsterRaceName = dungeonGuardianGameConfiguration.MonsterRaceName;
        LevelFound = dungeonGuardianGameConfiguration.LevelFound;
    }

    public override string Key { get; }
    public override int LevelFound { get; }

    protected override string MonsterRaceName { get; }
}
