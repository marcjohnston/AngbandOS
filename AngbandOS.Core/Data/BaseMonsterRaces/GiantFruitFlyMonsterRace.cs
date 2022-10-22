using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GiantFruitFlyMonsterRace : Base2MonsterRace
    {
        public override char Character => 'I';
        public override Colour Colour => Colour.BrightOrange;
        public override string Name => "Giant fruit fly";

        public override bool Animal => true;
        public override int ArmourClass => 14;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 2;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
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
        public override string Description => "A fast-breeding, annoying pest.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant fruit fly";
        public override int Hdice => 2;
        public override int Hside => 2;
        public override int Level => 10;
        public override int Mexp => 4;
        public override bool Multiply => true;
        public override int NoticeRange => 8;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 6;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "   fruit    ";
        public override string SplitName3 => "    fly     ";
        public override bool WeirdMind => true;
    }
}
