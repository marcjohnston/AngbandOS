namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class SummonMonsterMonsterSpell : SummonMonsterSpell
{
    protected override string SummonName(Monster monster) => "help";

    /// <summary>
    /// Returns null, to summon any monster.
    /// </summary>
    protected override MonsterSelector? MonsterSelector(Monster monster) => null;

    /// <summary>
    /// Returns 1, to summon a single monster.
    /// </summary>
    protected override int MaximumSummonCount(SaveGame saveGame) => 1;
}
