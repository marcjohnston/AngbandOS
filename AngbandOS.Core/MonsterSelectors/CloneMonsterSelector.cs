namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class CloneMonsterSelector : MonsterSelector
    {
        private MonsterRace _race;

        public CloneMonsterSelector(MonsterRace race)
        {
            _race = race;
        }

        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return rPtr.Index == _race.Index;
        }
    }
}
