namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class SummonUndeadMonsterSpell : SummonMonsterSpell
{
    protected override string SummonName(Monster monster) => "an undead adversary";

    protected override int MaximumSummonCount(SaveGame saveGame) => 1;

    protected override MonsterSelector? MonsterSelector(Monster monster) => new UndeadMonsterSelector();
}
