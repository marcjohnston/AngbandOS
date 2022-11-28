using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class TreasureMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            if (rPtr.Unique)
            {
                return false;
            }
            if (!(rPtr.Character == '!' || rPtr.Character == '|' || rPtr.Character == '$' || rPtr.Character == '?' ||
                  rPtr.Character == '='))
            {
                return false;
            }
            return true;
        }
    }
}
