using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class VibrationHoundMonsterRace : Base2MonsterRace
    {
        public override char Character => 'Z';
        public override Colour Colour => Colour.BrightOrange;
        public override string Name => "Vibration hound";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 3;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Claw;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 3;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Claw;
        public override bool BashDoor => true;
        public override bool BreatheSound => true;
        public override string Description => "A blurry canine form which seems to be moving as fast as the eye can follow. You can feel the earth resonating beneath your feet.";
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Vibration hound";
        public override bool Friends => true;
        public override int Hdice => 25;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 27;
        public override int Mexp => 250;
        public override int NoticeRange => 30;
        public override int Rarity => 3;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " Vibration  ";
        public override string SplitName3 => "   hound    ";
    }
}
