namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class Arrow5D6MonsterSpell : ArrowProjectileMonsterSpell
{
    protected override string ActionName => "fires a missile";
    protected override int Damage(Monster monster) => Program.Rng.DiceRoll(5, 6);
}
