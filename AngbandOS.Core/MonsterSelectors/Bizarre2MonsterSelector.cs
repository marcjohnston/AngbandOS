namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class Bizarre2MonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return rPtr.Character == 'b' && !rPtr.Unique;
        }
    }
}
