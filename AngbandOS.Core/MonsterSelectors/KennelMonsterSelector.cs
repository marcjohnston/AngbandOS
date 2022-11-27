using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    internal class KennelMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, int rIdx)
        {
            MonsterRace rPtr = saveGame.MonsterRaces[rIdx];
            if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0)
            {
                return false;
            }
            return rPtr.Character == 'Z' || rPtr.Character == 'C';
        }
    }
}
