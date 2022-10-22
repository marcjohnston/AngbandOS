using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class LargeBrownSnakeMonsterRace : Base2MonsterRace
    {
        public override char Character => 'J';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Large brown snake";

        public override bool Animal => true;
        public override int ArmourClass => 35;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 3;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 4;
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
        public override string Description => "It is about eight feet long.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Large brown snake";
        public override int Hdice => 4;
        public override int Hside => 6;
        public override int Level => 1;
        public override int Mexp => 3;
        public override int NoticeRange => 4;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 99;
        public override int Speed => 100;
        public override string SplitName1 => "   Large    ";
        public override string SplitName2 => "   brown    ";
        public override string SplitName3 => "   snake    ";
    }
}
