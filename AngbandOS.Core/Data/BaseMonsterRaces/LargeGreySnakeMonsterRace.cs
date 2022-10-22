using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class LargeGreySnakeMonsterRace : Base2MonsterRace
    {
        public override char Character => 'J';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Large grey snake";

        public override bool Animal => true;
        public override int ArmourClass => 41;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 5;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 8;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Crush;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "It is about ten feet long.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Large grey snake";
        public override int Hdice => 6;
        public override int Hside => 8;
        public override int Level => 4;
        public override int Mexp => 14;
        public override int NoticeRange => 6;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 50;
        public override int Speed => 100;
        public override string SplitName1 => "   Large    ";
        public override string SplitName2 => "    grey    ";
        public override string SplitName3 => "   snake    ";
    }
}
