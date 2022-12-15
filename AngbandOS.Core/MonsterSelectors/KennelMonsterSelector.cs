using AngbandOS.Core.MonsterRaces;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class KennelMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            if (rPtr.Unique)
            {
                return false;
            }
            return rPtr.Character == 'Z' || rPtr.Character == 'C';
        }
    }
}
