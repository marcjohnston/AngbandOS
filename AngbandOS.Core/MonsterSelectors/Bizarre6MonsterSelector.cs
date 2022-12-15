using AngbandOS.Core.MonsterRaces;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class Bizarre6MonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return (rPtr.Character == '!' || rPtr.Character == '?' || rPtr.Character == '=' || rPtr.Character == '$' || rPtr.Character == '|') && !rPtr.Unique;
        }
    }
}
