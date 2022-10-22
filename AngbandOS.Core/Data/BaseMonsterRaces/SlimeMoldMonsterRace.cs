using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class SlimeMoldMonsterRace : Base2MonsterRace
    {
        public override char Character => ',';
        public override Colour Colour => Colour.Green;
        public override string Name => "Slime mold";

        public override int ArmourClass => 4;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 4;
        public override AttackEffect Attack1Effect => AttackEffect.Poison;
        public override AttackType Attack1Type => AttackType.Crawl;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override AttackEffect Attack2Effect => AttackEffect.EatFood;
        public override AttackType Attack2Type => AttackType.Crawl;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Drool;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Drool;
        public override string Description => "It is a smallish, slimy, icky, hungry creature.";
        public override bool Drop90 => true;
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Slime mold";
        public override int Hdice => 5;
        public override int Hside => 6;
        public override bool ImmunePoison => true;
        public override bool KillBody => true;
        public override int Level => 2;
        public override int Mexp => 8;
        public override int NoticeRange => 14;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Slime    ";
        public override string SplitName3 => "    mold    ";
        public override bool TakeItem => true;
    }
}
