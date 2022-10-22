using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class LawGhostMonsterRace : Base2MonsterRace
    {
        public override char Character => 'G';
        public override Colour Colour => Colour.Silver;
        public override string Name => "Law ghost";

        public override int ArmourClass => 30;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override AttackEffect Attack1Effect => AttackEffect.Exp80;
        public override AttackType Attack1Type => AttackType.Touch;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override AttackEffect Attack2Effect => AttackEffect.Exp40;
        public override AttackType Attack2Type => AttackType.Touch;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 10;
        public override AttackEffect Attack3Effect => AttackEffect.LoseInt;
        public override AttackType Attack3Type => AttackType.Claw;
        public override int Attack4DDice => 1;
        public override int Attack4DSides => 10;
        public override AttackEffect Attack4Effect => AttackEffect.LoseWis;
        public override AttackType Attack4Type => AttackType.Claw;
        public override bool ColdBlood => true;
        public override string Description => "An almost life-like creature which is nothing more than a phantom created by the law.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Law ghost";
        public override int Hdice => 20;
        public override int Hside => 25;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 36;
        public override int Mexp => 400;
        public override bool MindBlast => true;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool PassWall => true;
        public override int Rarity => 3;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Law     ";
        public override string SplitName3 => "   ghost    ";
        public override bool Undead => true;
    }
}
