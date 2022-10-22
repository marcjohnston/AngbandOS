using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BeholderMonsterRace : Base2MonsterRace
    {
        public override char Character => 'e';
        public override Colour Colour => Colour.Green;
        public override string Name => "Beholder";

        public override bool AcidBolt => true;
        public override int ArmourClass => 80;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 4;
        public override AttackEffect Attack1Effect => AttackEffect.Exp20;
        public override AttackType Attack1Type => AttackType.Gaze;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 4;
        public override AttackEffect Attack2Effect => AttackEffect.Paralyze;
        public override AttackType Attack2Type => AttackType.Gaze;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 6;
        public override AttackEffect Attack3Effect => AttackEffect.LoseInt;
        public override AttackType Attack3Type => AttackType.Gaze;
        public override int Attack4DDice => 2;
        public override int Attack4DSides => 6;
        public override AttackEffect Attack4Effect => AttackEffect.UnPower;
        public override AttackType Attack4Type => AttackType.Gaze;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool ColdBolt => true;
        public override bool Confuse => true;
        public override bool Darkness => true;
        public override string Description => "A disembodied eye, surrounded by twelve smaller eyes on stalks.";
        public override bool DrainMana => true;
        public override bool Evil => true;
        public override bool FireBolt => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Beholder";
        public override int Hdice => 16;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 38;
        public override int Mexp => 6000;
        public override bool MindBlast => true;
        public override int NoticeRange => 30;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override bool Slow => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Beholder  ";
    }
}
