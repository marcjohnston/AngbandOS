using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class WoodSpiderMonsterRace : Base2MonsterRace
    {
        public override char Character => 'S';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Wood spider";

        public override bool Animal => true;
        public override int ArmourClass => 16;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 3;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 4;
        public override BaseAttackEffect? Attack2Effect => new PoisonAttackEffect();
        public override AttackType Attack2Type => AttackType.Sting;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "It scuttles towards you.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Wood spider";
        public override bool Friends => true;
        public override int Hdice => 3;
        public override int Hside => 6;
        public override bool ImmunePoison => true;
        public override int Level => 7;
        public override int Mexp => 15;
        public override int NoticeRange => 8;
        public override int Rarity => 3;
        public override int Sleep => 80;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Wood    ";
        public override string SplitName3 => "   spider   ";
        public override bool WeirdMind => true;
    }
}
