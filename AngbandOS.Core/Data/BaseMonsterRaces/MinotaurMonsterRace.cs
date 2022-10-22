using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class MinotaurMonsterRace : Base2MonsterRace
    {
        public override char Character => 'H';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Minotaur";

        public override int ArmourClass => 25;
        public override int Attack1DDice => 4;
        public override int Attack1DSides => 6;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Butt;
        public override int Attack2DDice => 4;
        public override int Attack2DSides => 6;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Butt;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 6;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 2;
        public override int Attack4DSides => 6;
        public override BaseAttackEffect? Attack4Effect => new HurtAttackEffect();
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override string Description => "It is a cross between a human and a bull.";
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Minotaur";
        public override int Hdice => 100;
        public override int Hside => 10;
        public override int Level => 40;
        public override int Mexp => 2100;
        public override int NoticeRange => 13;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Minotaur  ";
    }
}
