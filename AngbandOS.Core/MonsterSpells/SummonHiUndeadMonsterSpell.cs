namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class SummonHiUndeadMonsterSpell : SummonMonsterSpell
    {
        protected override string SummonName(Monster monster) => "greater undead";

        protected override int MaximumSummonCount(SaveGame saveGame) => 8;

        protected override MonsterSelector? MonsterSelector(Monster monster) => new HiUndeadMonsterSelector();
    }
}
