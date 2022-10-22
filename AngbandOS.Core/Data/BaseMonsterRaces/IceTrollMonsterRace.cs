using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class IceTrollMonsterRace : Base2MonsterRace
    {
        public override char Character => 'T';
        public override string Name => "Ice troll";

        public override int ArmourClass => 56;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 5;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.Cold;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "He is a white troll with powerfully clawed hands.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Ice troll";
        public override bool Friends => true;
        public override int Hdice => 24;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override int Level => 28;
        public override bool Male => true;
        public override int Mexp => 160;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Ice     ";
        public override string SplitName3 => "   troll    ";
        public override bool Troll => true;
    }
}
