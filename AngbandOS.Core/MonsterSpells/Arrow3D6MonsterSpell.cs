namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class Arrow3D6MonsterSpell : ArrowProjectileMonsterSpell
{
    protected override int Damage(Monster monster) => Program.Rng.DiceRoll(3, 6);
}
