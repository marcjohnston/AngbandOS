using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GreenGluttonGhostMonsterRace : Base2MonsterRace
    {
        public override char Character => 'G';
        public override Colour Colour => Colour.Green;
        public override string Name => "Green glutton ghost";

        public override int ArmourClass => 20;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 1;
        public override AttackEffect Attack1Effect => AttackEffect.EatFood;
        public override AttackType Attack1Type => AttackType.Touch;
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
        public override bool ColdBlood => true;
        public override string Description => "It is a very ugly green ghost with a voracious appetite.";
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Green glutton ghost";
        public override int Hdice => 3;
        public override int Hside => 4;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 5;
        public override int Mexp => 15;
        public override int NoticeRange => 10;
        public override bool PassWall => true;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 130;
        public override string SplitName1 => "   Green    ";
        public override string SplitName2 => "  glutton   ";
        public override string SplitName3 => "   ghost    ";
        public override bool Undead => true;
    }
}
