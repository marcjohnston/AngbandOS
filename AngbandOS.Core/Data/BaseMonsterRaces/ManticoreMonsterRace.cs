using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ManticoreMonsterRace : Base2MonsterRace
    {
        public override char Character => 'H';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Manticore";

        public override int ArmourClass => 15;
        public override bool Arrow7D6 => true;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 4;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 4;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 4;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 4;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override string Description => "It is a winged lion's body with a human torso and a tail covered in vicious spikes.";
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Manticore";
        public override int Hdice => 25;
        public override int Hside => 10;
        public override int Level => 30;
        public override int Mexp => 300;
        public override int NoticeRange => 12;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Manticore  ";
    }
}
