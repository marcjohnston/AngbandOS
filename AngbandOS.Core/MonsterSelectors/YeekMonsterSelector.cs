﻿using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class YeekMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return rPtr.Character == 'y' && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
        }
    }
}