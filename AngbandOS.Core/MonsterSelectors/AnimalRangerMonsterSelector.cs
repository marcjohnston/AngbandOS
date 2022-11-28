using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class AnimalRangerMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return rPtr.Animal &&
                    "abcflqrwBCIJKMRS".Contains(rPtr.Character.ToString()) &&
                    !rPtr.Dragon && !rPtr.Evil &&
                    !rPtr.Undead && !rPtr.Demon &&
                    !rPtr.Cthuloid && rPtr.Flags4 == 0 && rPtr.Flags5 == 0 &&
                    rPtr.Flags6 == 0 && !rPtr.Unique;
        }
    }
}
