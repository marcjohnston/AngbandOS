using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ScruffyLookingHobbitMonsterRace : Base2MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.BrightOrange;
        public override string Name => "Scruffy looking hobbit";

        public override int ArmourClass => 8;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 4;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override BaseAttackEffect? Attack2Effect => new EatGoldAttackEffect();
        public override AttackType Attack2Type => AttackType.Touch;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "A short little guy, in bedraggled clothes. He appears to be looking for a good tavern.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Scruffy looking hobbit";
        public override int Hdice => 3;
        public override int Hside => 5;
        public override int Level => 3;
        public override bool Male => true;
        public override int Mexp => 4;
        public override int NoticeRange => 16;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "  Scruffy   ";
        public override string SplitName2 => "  looking   ";
        public override string SplitName3 => "   hobbit   ";
        public override bool TakeItem => true;
    }
}
