﻿using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class PlaceMonsterOkayMonsterSelector : MonsterSelector
    {
        private int _placeMonsterIdx;
        public PlaceMonsterOkayMonsterSelector(int placeMonsterIdx)
        {
            _placeMonsterIdx = placeMonsterIdx;
        }

        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            MonsterRace pPtr = saveGame.MonsterRaces[_placeMonsterIdx];
            if (rPtr.Character != pPtr.Character)
            {
                return false;
            }
            if (rPtr.Level > pPtr.Level)
            {
                return false;
            }
            if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0)
            {
                return false;
            }
            if (_placeMonsterIdx == rPtr.Index)
            {
                return false;
            }
            return true;
        }
    }
}