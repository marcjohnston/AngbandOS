using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class MetallicBlueCentipedeMonsterRace : Base2MonsterRace
    {
        public override char Character => 'c';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Metallic blue centipede";

        public override bool Animal => true;
        public override int ArmourClass => 6;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 2;
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
        public override string FriendlyName => "Metallic blue centipede";
        public override int Hdice => 4;
        public override int Hside => 5;
        public override int Level => 3;
        public override int Mexp => 7;
        public override int NoticeRange => 6;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 15;
        public override int Speed => 120;
        public override string SplitName1 => "  Metallic  ";
        public override string SplitName2 => "    blue    ";
        public override string SplitName3 => " centipede  ";
        public override bool WeirdMind => true;
    }
}
