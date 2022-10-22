using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class CreepingSilverCoinsMonsterRace : Base2MonsterRace
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Silver;
        public override string Name => "Creeping silver coins";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.Poison;
        public override AttackType Attack2Type => AttackType.Touch;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a pile of coins, crawling forward on thousands of tiny legs.";
        public override bool Drop_1D2 => true;
        public override bool Drop60 => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Creeping silver coins";
        public override int Hdice => 12;
        public override int Hside => 8;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 6;
        public override int Mexp => 18;
        public override int NoticeRange => 4;
        public override bool OnlyDropGold => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 100;
        public override string SplitName1 => "  Creeping  ";
        public override string SplitName2 => "   silver   ";
        public override string SplitName3 => "   coins    ";
    }
}
