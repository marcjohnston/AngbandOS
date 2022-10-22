using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class CarrionCrawlerMonsterRace : Base2MonsterRace
    {
        public override char Character => 'c';
        public override Colour Colour => Colour.Green;
        public override string Name => "Carrion crawler";

        public override bool Animal => true;
        public override int ArmourClass => 40;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Paralyze;
        public override AttackType Attack1Type => AttackType.Sting;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.Paralyze;
        public override AttackType Attack2Type => AttackType.Sting;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "A hideous centipede covered in slime and with glowing tentacles around its head.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Carrion crawler";
        public override bool Friends => true;
        public override int Hdice => 20;
        public override int Hside => 12;
        public override bool ImmunePoison => true;
        public override int Level => 34;
        public override int Mexp => 100;
        public override int NoticeRange => 15;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Carrion   ";
        public override string SplitName3 => "  crawler   ";
        public override bool WeirdMind => true;
    }
}
