using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class HiUndeadNoUniquesMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return (rPtr.Character == 'L' || rPtr.Character == 'V' || rPtr.Character == 'W') && !rPtr.Unique;
        }
    }
}
