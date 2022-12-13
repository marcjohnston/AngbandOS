using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class TrapperMonsterRace : MonsterRace
    {
        public override char Character => '·';
        public override string Name => "Trapper";

        public override int ArmourClass => 75;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 8),
            new MonsterAttack(AttackType.Hit, new ParalyzeAttackEffect(), 15, 1),
            new MonsterAttack(AttackType.Hit, new ParalyzeAttackEffect(), 15, 1)
        };
        public override bool AttrClear => true;
        public override bool CharClear => true;
        public override bool ColdBlood => true;
        public override string Description => "This creature traps unsuspecting victims and paralyzes them, to be slowly digested later.";
        public override bool EmptyMind => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Trapper";
        public override int Hdice => 60;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 36;
        public override int Mexp => 580;
        public override bool NeverMove => true;
        public override int NoticeRange => 30;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Trapper   ";
    }
}
