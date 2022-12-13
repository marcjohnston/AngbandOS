using AngbandOS.Core.MonsterRaces;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class CauseCriticalWoundsMonsterSpell : CauseWoundsMonsterSpell
    {
        public override bool IsAttack => true;
        public override bool Annoys => true;
        protected override int CurseEquipmentChance => 80;
        protected override int HeavyCurseEquipmentChance => 15;
        protected override int Damage => Program.Rng.DiceRoll(10, 15);
        public override string? VsPlayerBlindMessage => $"You hear someone mumble loudly.";
        public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} points at you, incanting terribly!";
        public override string? VsMonsterUnseenMessage => $"You hear someone mumble.";
        public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} points at {target.Name}, incanting terribly!";
    }
}
