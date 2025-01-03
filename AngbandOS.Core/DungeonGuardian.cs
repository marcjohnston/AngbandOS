﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core;

[Serializable]
internal abstract class DungeonGuardian : IGetKey
{
    protected readonly Game Game;
    protected DungeonGuardian(Game game)
    {
        Game = game;
    }

    public virtual string Key => GetType().Name;

    public MonsterRace MonsterRace { get; private set; }

    /// <summary>
    /// The name of the race of the dungeon guardian.
    /// </summary>
    protected abstract string MonsterRaceName { get; }

    /// <summary>
    /// The level for the fixed quest.
    /// </summary>
    public abstract int LevelFound { get; }

    public string GetKey => Key;

    public void Bind()
    {
        MonsterRace = Game.SingletonRepository.Get<MonsterRace>(MonsterRaceName);
    }

    public string ToJson()
    {
        DungeonGuardianGameConfiguration dungeonGuardian = new()
        {
            Key = Key,
            MonsterRaceName = MonsterRaceName,
            LevelFound = LevelFound
        };
        return JsonSerializer.Serialize(dungeonGuardian, Game.GetJsonSerializerOptions());
    }
}