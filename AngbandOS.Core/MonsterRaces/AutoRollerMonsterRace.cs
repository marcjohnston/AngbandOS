using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class AutoRollerMonsterRace : MonsterRace
    {
        public override char Character => 'g';
        public override string Name => "Auto-roller";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 1, 7),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 1, 8)
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "It looks like a huge spiked roller, moving on its own towards you.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Auto-roller";
        public override int Hdice => 70;
        public override int Hside => 12;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 22;
        public override int Mexp => 230;
        public override bool Nonliving => true;
        public override int NoticeRange => 10;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override int Sleep => 12;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "Auto-roller ";
    }
}
