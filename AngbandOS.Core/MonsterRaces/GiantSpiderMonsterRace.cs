using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GiantSpiderMonsterRace : MonsterRace
    {
        public override char Character => 'S';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Giant spider";

        public override bool Animal => true;
        public override int ArmourClass => 16;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Bite, new PoisonAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Bite, new PoisonAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 10)
        };
        public override bool BashDoor => true;
        public override string Description => "It is a vast black spider whose bulbous body is bloated with poison.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant spider";
        public override int Hdice => 10;
        public override int Hside => 10;
        public override bool ImmunePoison => true;
        public override int LevelFound => 10;
        public override int Mexp => 35;
        public override int NoticeRange => 8;
        public override int Rarity => 2;
        public override int Sleep => 80;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Giant    ";
        public override string SplitName3 => "   spider   ";
        public override bool WeirdMind => true;
    }
}