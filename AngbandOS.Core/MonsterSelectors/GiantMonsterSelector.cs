using AngbandOS.Core.MonsterRaces;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class GiantMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            if (rPtr.Unique)
            {
                return false;
            }
            if (rPtr.Character != 'P')
            {
                return false;
            }
            return true;
        }
    }
}
