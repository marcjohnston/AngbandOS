using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    internal class SymbolMonsterSelector : MonsterSelector
    {
        private int _templateRace;

        public SymbolMonsterSelector(int templateRace)
        {
            _templateRace = templateRace;
        }

        public override bool Matches(SaveGame saveGame, int rIdx)
        {
            return saveGame.MonsterRaces[rIdx].Character == saveGame.MonsterRaces[_templateRace].Character && (saveGame.MonsterRaces[rIdx].Flags1 & MonsterFlag1.Unique) == 0;
        }
    }
}
