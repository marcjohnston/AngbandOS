using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class EtherealDrakeMonsterRace : Base2MonsterRace
    {
        public override char Character => 'd';
        public override Colour Colour => Colour.BrightGrey;
        public override string Name => "Ethereal drake";

        public override int ArmourClass => 100;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 8;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 8;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 6;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BreatheDark => true;
        public override bool BreatheLight => true;
        public override bool Confuse => true;
        public override string Description => "A dragon of elemental power, with control over light and dark, the ethereal drake's eyes glare with white hatred from the shadows.";
        public override bool Dragon => true;
        public override bool Drop_2D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Ethereal drake";
        public override int Hdice => 45;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 33;
        public override int Mexp => 700;
        public override int NoticeRange => 25;
        public override bool OnlyDropItem => true;
        public override bool PassWall => true;
        public override int Rarity => 3;
        public override bool Scare => true;
        public override int Sleep => 15;
        public override bool Slow => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Ethereal  ";
        public override string SplitName3 => "   drake    ";
    }
}
