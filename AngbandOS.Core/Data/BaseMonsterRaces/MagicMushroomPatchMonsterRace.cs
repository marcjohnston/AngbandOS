using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class MagicMushroomPatchMonsterRace : Base2MonsterRace
    {
        public override char Character => ',';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Magic mushroom patch";

        public override int ArmourClass => 10;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override BaseAttackEffect? Attack1Effect => null;
        public override AttackType Attack1Type => AttackType.Nothing;
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
        public override bool Blink => true;
        public override bool Darkness => true;
        public override string Description => "Yum! It looks quite tasty. It seems to glow with an unusual light.";
        public override bool ForceSleep => true;
        public override int FreqInate => 1;
        public override int FreqSpell => 1;
        public override string FriendlyName => "Magic mushroom patch";
        public override bool Friends => true;
        public override int Hdice => 1;
        public override int Hside => 1;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int Level => 15;
        public override int Mexp => 10;
        public override bool NeverAttack => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 40;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 0;
        public override bool Slow => true;
        public override int Speed => 130;
        public override string SplitName1 => "   Magic    ";
        public override string SplitName2 => "  mushroom  ";
        public override string SplitName3 => "   patch    ";
        public override bool Stupid => true;
    }
}
