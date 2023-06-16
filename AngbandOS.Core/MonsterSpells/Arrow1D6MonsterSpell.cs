namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class Arrow1D6MonsterSpell : ArrowProjectileMonsterSpell
{
    protected override int Damage(Monster monster) => Program.Rng.DiceRoll(1, 6);
}
