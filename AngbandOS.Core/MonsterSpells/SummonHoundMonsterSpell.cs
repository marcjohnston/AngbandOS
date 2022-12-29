namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class SummonHoundMonsterSpell : SummonMonsterSpell
    {
        protected override string SummonName(Monster monster) => "hounds";

        protected override MonsterSelector? MonsterSelector(Monster monster) => new HoundMonsterSelector();
    }
}
