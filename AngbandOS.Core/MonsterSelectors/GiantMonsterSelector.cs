﻿using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class GiantMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0)
            {
                return false;
            }
            if (rPtr.Character != 'P')
            {
                return false;
            }
            return true;
        }
    }
}