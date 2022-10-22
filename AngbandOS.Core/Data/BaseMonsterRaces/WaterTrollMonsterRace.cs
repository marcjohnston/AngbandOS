using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class WaterTrollMonsterRace : Base2MonsterRace
    {
        public override char Character => 'T';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Water troll";

        public override int ArmourClass => 50;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 9;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 9;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 2;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 2;
        public override int Attack4DSides => 2;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override string Description => "He is a troll that reeks of brine.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Water troll";
        public override bool Friends => true;
        public override int Hdice => 36;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmunePoison => true;
        public override int Level => 33;
        public override bool Male => true;
        public override int Mexp => 420;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Water    ";
        public override string SplitName3 => "   troll    ";
        public override bool Troll => true;
    }
}
