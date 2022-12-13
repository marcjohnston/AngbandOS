using AngbandOS.Core.MonsterSelectors;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class SummonMonstersMonsterSpell : SummonMonsterSpell
    {
        protected override string SummonName(Monster monster) => "monsters";

        /// <summary>
        /// Returns 8, to summon upto 8 monsters.
        /// </summary>
        protected override int MaximumSummonCount(SaveGame saveGame) => 8;

        /// <summary>
        /// Returns null, for any monster to be summoned.
        /// </summary>
        protected override MonsterSelector? MonsterSelector(Monster monster) => null;

        protected override MonsterSelector? FriendlyMonsterSelector(Monster monster) => new NoUniquesMonsterSelector();
    }
}
