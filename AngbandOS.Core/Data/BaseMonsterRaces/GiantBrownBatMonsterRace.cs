using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GiantBrownBatMonsterRace : Base2MonsterRace
    {
        public override char Character => 'b';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Giant brown bat";

        public override bool Animal => true;
        public override int ArmourClass => 15;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 3;
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
        public override string Description => "It screeches as it attacks.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant brown bat";
        public override int Hdice => 3;
        public override int Hside => 8;
        public override int Level => 6;
        public override int Mexp => 10;
        public override int NoticeRange => 10;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 30;
        public override int Speed => 130;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "   brown    ";
        public override string SplitName3 => "    bat     ";
    }
}
