using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class MirkwoodSpiderMonsterRace : Base2MonsterRace
    {
        public override char Character => 'S';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Mirkwood spider";

        public override bool Animal => true;
        public override int ArmourClass => 25;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 8;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.Poison;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 6;
        public override AttackEffect Attack3Effect => AttackEffect.Poison;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "A strong and powerful spider from Mirkwood forest. Cunning and evil, it seeks to taste your juicy insides.";
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Mirkwood spider";
        public override bool Friends => true;
        public override int Hdice => 9;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override bool ImmunePoison => true;
        public override int Level => 15;
        public override int Mexp => 25;
        public override int NoticeRange => 15;
        public override int Rarity => 2;
        public override int Sleep => 80;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Mirkwood  ";
        public override string SplitName3 => "   spider   ";
        public override bool WeirdMind => true;
    }
}
