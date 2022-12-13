using AngbandOS.Core.MonsterSelectors;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class SummonDragonMonsterSpell : SummonMonsterSpell
    {
        protected override string SummonName(Monster monster) => "a dragon";

        protected override int MaximumSummonCount(SaveGame saveGame) => 1;

        protected override MonsterSelector? MonsterSelector(Monster monster) => new DragonMonsterSelector();
    }
}
