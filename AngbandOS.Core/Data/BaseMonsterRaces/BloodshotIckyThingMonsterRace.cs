using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BloodshotIckyThingMonsterRace : Base2MonsterRace
    {
        public override char Character => 'i';
        public override Colour Colour => Colour.Red;
        public override string Name => "Bloodshot icky thing";

        public override int ArmourClass => 18;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 4;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Touch;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 4;
        public override AttackEffect Attack2Effect => AttackEffect.Acid;
        public override AttackType Attack2Type => AttackType.Crawl;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override string Description => "It is a strange, slimy, icky creature.";
        public override bool DrainMana => true;
        public override bool EmptyMind => true;
        public override int FreqInate => 11;
        public override int FreqSpell => 11;
        public override string FriendlyName => "Bloodshot icky thing";
        public override int Hdice => 7;
        public override int Hside => 8;
        public override bool ImmunePoison => true;
        public override int Level => 9;
        public override int Mexp => 24;
        public override int NoticeRange => 14;
        public override bool RandomMove50 => true;
        public override int Rarity => 3;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => " Bloodshot  ";
        public override string SplitName2 => "    icky    ";
        public override string SplitName3 => "   thing    ";
    }
}
