namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class CauseSeriousWoundsMonsterSpell : CauseWoundsMonsterSpell
    {
        public override bool IsAttack => true;
        public override bool Annoys => true;
        protected override int CurseEquipmentChance => 50;
        protected override int HeavyCurseEquipmentChance => 5;
        protected override int Damage => Program.Rng.DiceRoll(8, 8);
        public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} points at {target.Name} and curses horribly.";
    }
}
