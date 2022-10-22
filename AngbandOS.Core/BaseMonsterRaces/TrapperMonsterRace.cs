using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class TrapperMonsterRace : Base2MonsterRace
    {
        public override char Character => '·';
        public override string Name => "Trapper";

        public override int ArmourClass => 75;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 8;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 8;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 15;
        public override int Attack3DSides => 1;
        public override BaseAttackEffect? Attack3Effect => new ParalyzeAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 15;
        public override int Attack4DSides => 1;
        public override BaseAttackEffect? Attack4Effect => new ParalyzeAttackEffect();
        public override AttackType Attack4Type => AttackType.Hit;
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
        public override int Level => 36;
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
