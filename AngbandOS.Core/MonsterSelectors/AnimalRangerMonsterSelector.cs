using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class AnimalRangerMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return (rPtr.Flags3 & MonsterFlag3.Animal) != 0 &&
                    "abcflqrwBCIJKMRS".Contains(rPtr.Character.ToString()) &&
                    (rPtr.Flags3 & MonsterFlag3.Dragon) == 0 && (rPtr.Flags3 & MonsterFlag3.Evil) == 0 &&
                    (rPtr.Flags3 & MonsterFlag3.Undead) == 0 && (rPtr.Flags3 & MonsterFlag3.Demon) == 0 &&
                    (rPtr.Flags3 & MonsterFlag3.Cthuloid) == 0 && rPtr.Flags4 == 0 && rPtr.Flags5 == 0 &&
                    rPtr.Flags6 == 0 && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
        }
    }
}
