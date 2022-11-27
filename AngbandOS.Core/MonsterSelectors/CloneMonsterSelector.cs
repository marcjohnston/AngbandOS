namespace AngbandOS.Core.MonsterSelectors
{
    internal class CloneMonsterSelector : MonsterSelector
    {
        private int _templateRace;

        public CloneMonsterSelector(int templateRace)
        {
            _templateRace = templateRace;
        }

        public override bool Matches(SaveGame saveGame, int rIdx)
        {
            return rIdx == _templateRace;
        }
    }
}
