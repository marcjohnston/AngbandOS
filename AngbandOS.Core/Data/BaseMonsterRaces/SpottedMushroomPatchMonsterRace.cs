using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class SpottedMushroomPatchMonsterRace : Base2MonsterRace
    {
        public override char Character => ',';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Spotted mushroom patch";

        public override int ArmourClass => 1;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 4;
        public override BaseAttackEffect? Attack1Effect => new PoisonAttackEffect();
        public override AttackType Attack1Type => AttackType.Spore;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override BaseAttackEffect? Attack2Effect => null;
        public override AttackType Attack2Type => AttackType.Nothing;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override string Description => "Yum! It looks quite tasty.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Spotted mushroom patch";
        public override int Hdice => 1;
        public override int Hside => 1;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 3;
        public override int Mexp => 3;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "  Spotted   ";
        public override string SplitName2 => "  mushroom  ";
        public override string SplitName3 => "   patch    ";
        public override bool Stupid => true;
    }
}
