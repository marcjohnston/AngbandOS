using AngbandOS.Core.MonsterSelectors;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class SummonGreatOldOneMonsterSpell : SummonMonsterSpell
    {
        protected override string SummonName(Monster monster) => "Great Old Ones";

        protected override int MaximumSummonCount(SaveGame saveGame) => 8;

        protected override MonsterSelector? MonsterSelector(Monster monster) => new GooMonsterSelector();
    }
}
