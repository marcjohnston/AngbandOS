using AngbandOS.Core.MonsterRaces;

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
