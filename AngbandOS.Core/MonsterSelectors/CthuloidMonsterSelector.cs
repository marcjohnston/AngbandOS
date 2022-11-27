using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class CthuloidMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return (rPtr.Flags3 & MonsterFlag3.Cthuloid) != 0 && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
        }
    }
}
