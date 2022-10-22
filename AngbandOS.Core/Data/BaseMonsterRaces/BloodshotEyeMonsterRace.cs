using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BloodshotEyeMonsterRace : Base2MonsterRace
    {
        public override char Character => 'e';
        public override Colour Colour => Colour.Red;
        public override string Name => "Bloodshot eye";

        public override int ArmourClass => 6;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Blind;
        public override AttackType Attack1Type => AttackType.Gaze;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override AttackEffect Attack2Effect => AttackEffect.Nothing;
        public override AttackType Attack2Type => AttackType.Nothing;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override string Description => "A disembodied eye, bloodshot and nasty.";
        public override bool DrainMana => true;
        public override int FreqInate => 7;
        public override int FreqSpell => 7;
        public override string FriendlyName => "Bloodshot eye";
        public override int Hdice => 5;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override bool ImmuneFear => true;
        public override int Level => 7;
        public override int Mexp => 15;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " Bloodshot  ";
        public override string SplitName3 => "    eye     ";
    }
}
