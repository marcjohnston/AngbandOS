using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GreenOozeMonsterRace : Base2MonsterRace
    {
        public override char Character => 'j';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Green ooze";

        public override int ArmourClass => 16;
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
        public override string Description => "It's green and it's oozing.";
        public override bool Drop90 => true;
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Green ooze";
        public override int Hdice => 3;
        public override int Hside => 4;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 3;
        public override int Mexp => 4;
        public override int NoticeRange => 8;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 2;
        public override int Sleep => 80;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Green    ";
        public override string SplitName3 => "    ooze    ";
        public override bool Stupid => true;
    }
}
