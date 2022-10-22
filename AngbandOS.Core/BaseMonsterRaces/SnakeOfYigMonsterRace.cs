using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class SnakeOfYigMonsterRace : Base2MonsterRace
    {
        public override char Character => 'J';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Snake of Yig";

        public override bool Animal => true;
        public override int ArmourClass => 80;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 12;
        public override BaseAttackEffect? Attack1Effect => new PoisonAttackEffect();
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 12;
        public override BaseAttackEffect? Attack2Effect => new PoisonAttackEffect();
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 12;
        public override BaseAttackEffect? Attack3Effect => new PoisonAttackEffect();
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool BreathePoison => true;
        public override string Description => "It is a giant snake that drips with poison.";
        public override bool Evil => true;
        public override bool FireAura => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Snake of Yig";
        public override bool Friends => true;
        public override int Hdice => 48;
        public override int Hside => 10;
        public override bool ImmuneFire => true;
        public override int Level => 83;
        public override int Mexp => 600;
        public override bool MoveBody => true;
        public override int NoticeRange => 25;
        public override bool RandomMove25 => true;
        public override int Rarity => 4;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "   Snake    ";
        public override string SplitName2 => "     of     ";
        public override string SplitName3 => "    Yig     ";
    }
}
