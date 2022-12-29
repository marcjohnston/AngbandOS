namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class SummonHiDragonMonsterSpell : SummonMonsterSpell
    {
        protected override string SummonName(Monster monster) => "ancient dragons";

        protected override int MaximumSummonCount(SaveGame saveGame) => 8;

        protected override MonsterSelector? MonsterSelector(Monster monster) => new HiDragonMonsterSelector();
    }
}