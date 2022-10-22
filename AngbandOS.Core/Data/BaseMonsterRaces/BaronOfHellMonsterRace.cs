using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BaronOfHellMonsterRace : Base2MonsterRace
    {
        public override char Character => 'U';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Baron of hell";

        public override int ArmourClass => 130;
        public override int Attack1DDice => 11;
        public override int Attack1DSides => 2;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 11;
        public override int Attack2DSides => 2;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 11;
        public override int Attack3DSides => 2;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Claw;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool Demon => true;
        public override string Description => "A minor demon lord with a goat's head, tough to kill.";
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Baron of hell";
        public override int Hdice => 150;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 38;
        public override bool Male => true;
        public override int Mexp => 900;
        public override bool Nonliving => true;
        public override int NoticeRange => 10;
        public override bool OpenDoor => true;
        public override bool PlasmaBolt => true;
        public override int Rarity => 3;
        public override bool ResistPlasma => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "   Baron    ";
        public override string SplitName2 => "     of     ";
        public override string SplitName3 => "    hell    ";
    }
}
