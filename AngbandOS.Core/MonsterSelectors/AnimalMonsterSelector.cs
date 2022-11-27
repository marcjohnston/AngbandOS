using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class AnimalMonsterSelector : MonsterSelector
    {
        /// <summary>
        /// Returns true, if a monster is not unique and is an animal.
        /// </summary>
        /// <param name="rIdx"></param>
        /// <returns></returns>
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return (rPtr.Flags3 & MonsterFlag3.Animal) != 0 && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
        }
    }
}
