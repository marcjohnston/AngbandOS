using AngbandOS.Core.MonsterRaces;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class Bizarre1MonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return rPtr.Character == 'm' && !rPtr.Unique;
        }
    }
}
