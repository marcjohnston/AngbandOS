using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class MetallicGreenCentipedeMonsterRace : Base2MonsterRace
    {
        public override char Character => 'c';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Metallic green centipede";

        public override bool Animal => true;
        public override int ArmourClass => 4;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 1;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Crawl;
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
        public override string Description => "It is about four feet long and carnivorous.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Metallic green centipede";
        public override int Hdice => 4;
        public override int Hside => 4;
        public override int Level => 2;
        public override int Mexp => 3;
        public override int NoticeRange => 5;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "  Metallic  ";
        public override string SplitName2 => "   green    ";
        public override string SplitName3 => " centipede  ";
        public override bool WeirdMind => true;
    }
}
