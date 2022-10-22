using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class CaveSpiderMonsterRace : Base2MonsterRace
    {
        public override char Character => 'S';
        public override Colour Colour => Colour.Black;
        public override string Name => "Cave spider";

        public override bool Animal => true;
        public override int ArmourClass => 16;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 4;
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
        public override bool BashDoor => true;
        public override string Description => "It is a black spider that moves in fits and starts.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Cave spider";
        public override bool Friends => true;
        public override int Hdice => 2;
        public override int Hside => 6;
        public override bool HurtByLight => true;
        public override int Level => 2;
        public override int Mexp => 7;
        public override int NoticeRange => 8;
        public override int Rarity => 1;
        public override int Sleep => 80;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Cave    ";
        public override string SplitName3 => "   spider   ";
        public override bool WeirdMind => true;
    }
}
