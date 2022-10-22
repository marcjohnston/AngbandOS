using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class CantorasTheSkeletalLordMonsterRace : Base2MonsterRace
    {
        public override char Character => 's';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Cantoras, the Skeletal Lord";

        public override int ArmourClass => 120;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override BaseAttackEffect? Attack1Effect => new Exp80AttackEffect();
        public override AttackType Attack1Type => AttackType.Gaze;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override BaseAttackEffect? Attack2Effect => new Exp80AttackEffect();
        public override AttackType Attack2Type => AttackType.Gaze;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 5;
        public override BaseAttackEffect? Attack3Effect => new PoisonAttackEffect();
        public override AttackType Attack3Type => AttackType.Touch;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 5;
        public override BaseAttackEffect? Attack4Effect => new PoisonAttackEffect();
        public override AttackType Attack4Type => AttackType.Touch;
        public override bool BashDoor => true;
        public override bool BrainSmash => true;
        public override bool CauseMortalWounds => true;
        public override bool ColdBlood => true;
        public override string Description => "A legion of evil undead druj animating the skeleton of a once mighty sorcerer. His power is devastating and his speed unmatched in the underworld. Flee his wrath!";
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 1;
        public override int FreqSpell => 1;
        public override string FriendlyName => "Cantoras, the Skeletal Lord";
        public override int Hdice => 75;
        public override int Hside => 100;
        public override bool IceBolt => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 84;
        public override bool Male => true;
        public override bool ManaBolt => true;
        public override int Mexp => 45000;
        public override bool NetherBall => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 80;
        public override bool Slow => true;
        public override bool Smart => true;
        public override int Speed => 140;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Cantoras  ";
        public override bool SummonHiUndead => true;
        public override bool TeleportTo => true;
        public override bool Undead => true;
        public override bool Unique => true;
        public override bool WaterBall => true;
    }
}
