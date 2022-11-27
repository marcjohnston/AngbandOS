using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    internal class PlaceMonsterOkayMonsterSelector : MonsterSelector
    {
        private int _placeMonsterIdx;
        public PlaceMonsterOkayMonsterSelector(int placeMonsterIdx)
        {
            _placeMonsterIdx = placeMonsterIdx;
        }

        public override bool Matches(SaveGame saveGame, int rIdx)
        {
            MonsterRace rPtr = saveGame.MonsterRaces[_placeMonsterIdx];
            MonsterRace zPtr = saveGame.MonsterRaces[rIdx];
            if (zPtr.Character != rPtr.Character)
            {
                return false;
            }
            if (zPtr.Level > rPtr.Level)
            {
                return false;
            }
            if ((zPtr.Flags1 & MonsterFlag1.Unique) != 0)
            {
                return false;
            }
            if (_placeMonsterIdx == rIdx)
            {
                return false;
            }
            return true;
        }
    }
}
