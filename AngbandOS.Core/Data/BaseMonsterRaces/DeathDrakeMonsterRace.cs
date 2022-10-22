using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class DeathDrakeMonsterRace : Base2MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Death drake";

        public override int ArmourClass => 100;
        public override int Attack1DDice => 4;
        public override int Attack1DSides => 10;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 4;
        public override int Attack2DSides => 10;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 6;
        public override AttackEffect Attack3Effect => AttackEffect.Exp80;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 6;
        public override AttackEffect Attack4Effect => AttackEffect.Exp80;
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool BreatheNether => true;
        public override bool Confuse => true;
        public override string Description => "It is a dragon-like form wrapped in darkness. You cannot make out its true form but you sense its evil.";
        public override bool Dragon => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Death drake";
        public override int Hdice => 10;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 40;
        public override int Mexp => 3500;
        public override bool MoveBody => true;
        public override int NoticeRange => 25;
        public override bool OnlyDropItem => true;
        public override bool PassWall => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override bool ResistNether => true;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 30;
        public override bool Slow => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Death    ";
        public override string SplitName3 => "   drake    ";
        public override bool TakeItem => true;
    }
}
