using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class BlueIckyThingMonsterRace : MonsterRace
    {
        public override char Character => 'i';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Blue icky thing";

        public override int ArmourClass => 20;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crawl, new PoisonAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Crawl, new EatFoodAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 4)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Confuse => true;
        public override string Description => "It is a strange, slimy, icky creature, with rudimentary intelligence, but evil cunning. It hungers for food, and you look tasty.";
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Blue icky thing";
        public override int Hdice => 10;
        public override int Hside => 6;
        public override bool ImmunePoison => true;
        public override int LevelFound => 14;
        public override int Mexp => 20;
        public override bool Multiply => true;
        public override int NoticeRange => 15;
        public override bool OpenDoor => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 4;
        public override bool Scare => true;
        public override int Sleep => 20;
        public override int Speed => 100;
        public override string SplitName1 => "    Blue    ";
        public override string SplitName2 => "    icky    ";
        public override string SplitName3 => "   thing    ";
    }
}
