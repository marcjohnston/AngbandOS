using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class MasterThiefMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Black;
        public override string Name => "Master thief";

        public override int ArmourClass => 30;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 8;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 4;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 4;
        public override int Attack3DSides => 4;
        public override BaseAttackEffect? Attack3Effect => new EatGoldAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 4;
        public override int Attack4DSides => 5;
        public override BaseAttackEffect? Attack4Effect => new EatItemAttackEffect();
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override string Description => "Cool and confident, fast and lithe; protect your possessions quickly!";
        public override bool Drop_2D2 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Master thief";
        public override int Hdice => 18;
        public override int Hside => 10;
        public override int Level => 34;
        public override bool Male => true;
        public override int Mexp => 350;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 40;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Master   ";
        public override string SplitName3 => "   thief    ";
        public override bool TakeItem => true;
    }
}
