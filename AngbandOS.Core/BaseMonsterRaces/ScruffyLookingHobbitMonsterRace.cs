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
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Touch, new EatGoldAttackEffect(), 0, 0),
        };
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
