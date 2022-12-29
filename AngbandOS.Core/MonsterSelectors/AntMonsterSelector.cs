namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class AntMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return rPtr.Character == 'a' && !rPtr.Unique;
        }
    }
}
