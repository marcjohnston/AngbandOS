using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class JellyMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0)
            {
                return false;
            }
            if ((rPtr.Flags3 & MonsterFlag3.Evil) != 0)
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
