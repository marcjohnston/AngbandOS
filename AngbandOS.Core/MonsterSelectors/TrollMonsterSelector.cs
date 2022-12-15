using AngbandOS.Core.MonsterRaces;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class TrollMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            if (rPtr.Unique)
            {
                return false;
            }
            if (rPtr.Character != 'T')
            {
                return false;
            }
            return true;
        }
    }
}
