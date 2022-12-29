namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class DemonMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return rPtr.Demon && !rPtr.Unique;
        }
    }
}
