﻿using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class UniqueMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return (rPtr.Flags1 & MonsterFlag1.Unique) != 0;
        }
    }
}