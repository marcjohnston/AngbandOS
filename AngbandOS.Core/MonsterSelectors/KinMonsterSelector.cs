﻿using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class KinMonsterSelector : MonsterSelector
    {
        private char _summonKinType;
        public KinMonsterSelector(char summonKinType)
        {
            _summonKinType = summonKinType;
        }

        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return rPtr.Character == _summonKinType && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
        }
    }
}