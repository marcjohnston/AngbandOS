using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GlaryssaSuccubusQueenMonsterRace : Base2MonsterRace
    {
        public override char Character => 'U';
        public override Colour Colour => Colour.BrightPink;
        public override string Name => "Glaryssa, Succubus Queen";

        public override bool AcidBolt => true;
        public override int ArmourClass => 60;
        public override int Attack1DDice => 5;
        public override int Attack1DSides => 5;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 5;
        public override int Attack2DSides => 5;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 4;
        public override int Attack3DSides => 4;
        public override AttackEffect Attack3Effect => AttackEffect.LoseStr;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 8;
        public override int Attack4DSides => 1;
        public override AttackEffect Attack4Effect => AttackEffect.Exp80;
        public override AttackType Attack4Type => AttackType.Touch;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool CauseCriticalWounds => true;
        public override bool ColdBlood => true;
        public override bool Darkness => true;
        public override bool Demon => true;
        public override string Description => "Drop dead gorgeous - literally.";
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Glaryssa, Succubus Queen";
        public override int Hdice => 12;
        public override bool Hold => true;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmunePoison => true;
        public override int Level => 41;
        public override int Mexp => 8000;
        public override bool MindBlast => true;
        public override bool MoveBody => true;
        public override bool NetherBolt => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 90;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool PassWall => true;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Glaryssa  ";
        public override bool SummonDemon => true;
        public override bool Unique => true;
    }
}
