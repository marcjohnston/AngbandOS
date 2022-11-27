using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    internal class ChapelMonsterSelector : MonsterSelector
    {
        /// <summary>
        /// Returns true, if a monster is not unique and is a Shaman.
        /// </summary>
        /// <param name="rIdx"></param>
        /// <returns></returns>
        public override bool Matches(SaveGame saveGame, int rIdx)
        {
            MonsterRace rPtr = saveGame.MonsterRaces[rIdx];
            if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0)
            {
                return false;
            }
            if (!rPtr.Name.Contains("haman"))
            {
                return false;
            }
            return true;
        }
    }
}
