namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class SummonUniqueMonsterSpell : SummonMonsterSpell
    {
        protected override string SummonName(Monster monster) => "special opponents";

        protected override MonsterSelector? MonsterSelector(Monster monster) => new UniqueMonsterSelector();

        protected override string BlindNonZeroSummonedMessage => "You hear many powerful things appear nearby.";
    }
}
