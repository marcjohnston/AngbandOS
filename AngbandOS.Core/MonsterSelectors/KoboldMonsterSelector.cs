namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class KoboldMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return rPtr.Character == 'k' && !rPtr.Unique;
        }
    }
}
