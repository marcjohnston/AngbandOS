using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class DragonMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return (rPtr.Flags3 & MonsterFlag3.Dragon) != 0 && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
        }
    }
}
