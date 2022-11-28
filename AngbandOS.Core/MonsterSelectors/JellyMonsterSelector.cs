using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class JellyMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            if (rPtr.Unique)
            {
                return false;
            }
            if (rPtr.Evil)
            {
                return false;
            }
            if (!"ijm,".Contains(rPtr.Character.ToString()))
            {
                return false;
            }
            return true;
        }
    }
}
