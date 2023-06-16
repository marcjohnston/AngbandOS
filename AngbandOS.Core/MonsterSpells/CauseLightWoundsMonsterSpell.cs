namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class CauseLightWoundsMonsterSpell : CauseWoundsMonsterSpell
{
    protected override int CurseEquipmentChance => 33;
    protected override int HeavyCurseEquipmentChance => 0;
    protected override int Damage => Program.Rng.DiceRoll(3, 8);
    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} points at {target.Name} and curses horribly.";
}
