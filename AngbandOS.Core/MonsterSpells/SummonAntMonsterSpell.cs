using AngbandOS.Core.MonsterSelectors;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class SummonAntMonsterSpell : SummonMonsterSpell
    {
        protected override string SummonName(Monster monster) => "ants";

        protected override MonsterSelector? MonsterSelector(Monster monster) => new AntMonsterSelector();
    }
}
