using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class TimeHoundMonsterRace : Base2MonsterRace
    {
        public override char Character => 'Z';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Time hound";

        public override bool Animal => true;
        public override int ArmourClass => 100;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 12;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 12;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 12;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 3;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Claw;
        public override bool BashDoor => true;
        public override bool BreatheTime => true;
        public override string Description => "You get a terrible sense of deja vu, or is it a premonition? All at once you see a little puppy and a toothless old dog. Perhaps you should give up and go to bed.";
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Time hound";
        public override bool Friends => true;
        public override int Hdice => 60;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 51;
        public override int Mexp => 5000;
        public override int NoticeRange => 30;
        public override bool OpenDoor => true;
        public override int Rarity => 4;
        public override int Sleep => 0;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Time    ";
        public override string SplitName3 => "   hound    ";
    }
}
