using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BasiliskMonsterRace : Base2MonsterRace
    {
        public override char Character => 'R';
        public override Colour Colour => Colour.Black;
        public override string Name => "Basilisk";

        public override bool Animal => true;
        public override int ArmourClass => 90;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override BaseAttackEffect? Attack1Effect => new ParalyzeAttackEffect();
        public override AttackType Attack1Type => AttackType.Gaze;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 12;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 12;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 2;
        public override int Attack4DSides => 12;
        public override BaseAttackEffect? Attack4Effect => new HurtAttackEffect();
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool BashDoor => true;
        public override bool BreathePoison => true;
        public override string Description => "An evil reptile whose eyes stare deeply at you and your soul starts to wilt!";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Basilisk";
        public override int Hdice => 20;
        public override int Hside => 30;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 28;
        public override int Mexp => 350;
        public override int NoticeRange => 15;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Basilisk  ";
    }
}
