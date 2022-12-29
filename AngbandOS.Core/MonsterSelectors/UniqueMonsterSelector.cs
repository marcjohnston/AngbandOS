namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class UniqueMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return rPtr.Unique;
        }
    }
}
