namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class HydraMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return rPtr.Character == 'M' && !rPtr.Unique;
        }
    }
}
