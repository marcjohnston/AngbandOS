﻿using AngbandOS.Core.MonsterRaces;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class HiDragonMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return rPtr.Character == 'D';
        }
    }
}