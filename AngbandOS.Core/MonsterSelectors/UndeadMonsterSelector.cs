namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class UndeadMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            if (rPtr.Unique)
            {
                return false;
            }
            if (!rPtr.Undead)
            {
                return false;
            }
            return true;
        }
    }
}
