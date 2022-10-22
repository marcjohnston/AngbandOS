using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class DholeMonsterRace : Base2MonsterRace
    {
        public override char Character => 'A';
        public override Colour Colour => Colour.Beige;
        public override string Name => "Dhole";

        public override bool Animal => true;
        public override int ArmourClass => 64;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 8;
        public override AttackEffect Attack1Effect => AttackEffect.Acid;
        public override AttackType Attack1Type => AttackType.Spit;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 8;
        public override AttackEffect Attack2Effect => AttackEffect.Acid;
        public override AttackType Attack2Type => AttackType.Engulf;
        public override int Attack3DDice => 4;
        public override int Attack3DSides => 8;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Crush;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BreatheAcid => true;
        public override bool Cthuloid => true;
        public override string Description => "A gigantic worm dripping with acid.";
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Dhole";
        public override int Hdice => 65;
        public override int Hside => 8;
        public override bool ImmuneAcid => true;
        public override bool KillWall => true;
        public override int Level => 29;
        public override int Mexp => 500;
        public override int NoticeRange => 14;
        public override int Rarity => 4;
        public override int Sleep => 25;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Dhole    ";
    }
}
