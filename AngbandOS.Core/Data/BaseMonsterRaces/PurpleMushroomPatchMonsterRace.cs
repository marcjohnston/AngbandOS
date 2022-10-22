using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class PurpleMushroomPatchMonsterRace : Base2MonsterRace
    {
        public override char Character => ',';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Purple mushroom patch";

        public override int ArmourClass => 1;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 2;
        public override AttackEffect Attack1Effect => AttackEffect.LoseCon;
        public override AttackType Attack1Type => AttackType.Spore;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 2;
        public override AttackEffect Attack2Effect => AttackEffect.LoseCon;
        public override AttackType Attack2Type => AttackType.Spore;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 2;
        public override AttackEffect Attack3Effect => AttackEffect.LoseCon;
        public override AttackType Attack3Type => AttackType.Spore;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override string Description => "Yum! It looks quite tasty.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Purple mushroom patch";
        public override int Hdice => 1;
        public override int Hside => 1;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int Level => 6;
        public override int Mexp => 15;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 2;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "   Purple   ";
        public override string SplitName2 => "  mushroom  ";
        public override string SplitName3 => "   patch    ";
        public override bool Stupid => true;
    }
}
