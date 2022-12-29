namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class CultMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            if (rPtr.Unique)
            {
                return false;
            }
            if (!rPtr.Name.Contains("Cult"))
            {
                return false;
            }
            return true;
        }
    }
}
