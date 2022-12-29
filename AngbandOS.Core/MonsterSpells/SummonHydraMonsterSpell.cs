namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class SummonHydraMonsterSpell : SummonMonsterSpell
    {
        protected override string SummonName(Monster monster) => "hydras";

        protected override MonsterSelector? MonsterSelector(Monster monster) => new HydraMonsterSelector();
    }
}
