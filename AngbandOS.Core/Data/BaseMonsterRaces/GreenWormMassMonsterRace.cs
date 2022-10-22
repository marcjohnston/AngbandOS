using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GreenWormMassMonsterRace : Base2MonsterRace
    {
        public override char Character => 'w';
        public override Colour Colour => Colour.Green;
        public override string Name => "Green worm mass";

        public override bool Animal => true;
        public override int ArmourClass => 3;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 3;
        public override AttackEffect Attack1Effect => AttackEffect.Acid;
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
        public override string Description => "It is a large slimy mass of worms.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Green worm mass";
        public override int Hdice => 6;
        public override int Hside => 4;
        public override bool HurtByLight => true;
        public override bool ImmuneAcid => true;
        public override bool ImmuneFear => true;
        public override int Level => 2;
        public override int Mexp => 3;
        public override bool Multiply => true;
        public override int NoticeRange => 7;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 100;
        public override string SplitName1 => "   Green    ";
        public override string SplitName2 => "    worm    ";
        public override string SplitName3 => "    mass    ";
        public override bool Stupid => true;
        public override bool WeirdMind => true;
    }
}
