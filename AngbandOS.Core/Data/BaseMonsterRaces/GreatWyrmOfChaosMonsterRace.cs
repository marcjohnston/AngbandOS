using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GreatWyrmOfChaosMonsterRace : Base2MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Great Wyrm of Chaos";

        public override int ArmourClass => 170;
        public override int Attack1DDice => 5;
        public override int Attack1DSides => 12;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 5;
        public override int Attack2DSides => 12;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 5;
        public override int Attack3DSides => 12;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Claw;
        public override int Attack4DDice => 8;
        public override int Attack4DSides => 14;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheChaos => true;
        public override bool BreatheDisenchant => true;
        public override bool Confuse => true;
        public override string Description => "A massive dragon of changing form. As you watch, it appears first fair and then foul. Its body is twisted by chaotic forces as it strives to stay real. Its very existence distorts the universe around it.";
        public override bool Dragon => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Great Wyrm of Chaos";
        public override int Hdice => 45;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 67;
        public override int Mexp => 29000;
        public override bool MoveBody => true;
        public override int NoticeRange => 40;
        public override bool OnlyDropItem => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override bool ResistDisenchant => true;
        public override bool Scare => true;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "   Great    ";
        public override string SplitName2 => "  Wyrm of   ";
        public override string SplitName3 => "   Chaos    ";
        public override bool SummonDragon => true;
    }
}
