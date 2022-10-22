using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class HellcatMonsterRace : Base2MonsterRace
    {
        public override char Character => 'f';
        public override Colour Colour => Colour.Red;
        public override string Name => "Hellcat";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 5;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 5;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 8;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override string Description => "It is as large as a tiger, its yellow eyes are pupilless.";
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Hellcat";
        public override bool Friends => true;
        public override int Hdice => 9;
        public override int Hside => 8;
        public override bool ImmuneFire => true;
        public override int Level => 12;
        public override int Mexp => 40;
        public override int NoticeRange => 20;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Hellcat   ";
        public override bool WeirdMind => true;
    }
}
