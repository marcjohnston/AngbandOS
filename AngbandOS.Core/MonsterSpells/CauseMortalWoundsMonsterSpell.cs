namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class CauseMortalWoundsMonsterSpell : CauseWoundsMonsterSpell
{
    public override bool IsAttack => true;
    protected override int CurseEquipmentChance => 0;
    protected override int HeavyCurseEquipmentChance => 0;
    protected override int Damage => Program.Rng.DiceRoll(15, 15);
    public override string? VsPlayerBlindMessage => $"You hear someone screams the word 'DIE!'";
    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} points at you, screaming the word DIE!";
    public override string? VsMonsterUnseenMessage => $"You hear someone mumble.";
    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} points at {target.Name}, screaming the word 'DIE!'";
    protected override int TimedBleeding => Program.Rng.DiceRoll(10, 10);
}
