using AngbandOS.Core.MonsterSelectors;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class SummonSpiderMonsterSpell : SummonMonsterSpell
    {
        protected override string SummonName(Monster monster) => "spiders";

        protected override MonsterSelector? MonsterSelector(Monster monster) => new SpiderMonsterSelector();
    }
}
