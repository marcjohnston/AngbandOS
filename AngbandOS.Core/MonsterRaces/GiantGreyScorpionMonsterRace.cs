using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GiantGreyScorpionMonsterRace : MonsterRace
    {
        public override char Character => 'S';
        public override Colour Colour => Colour.BrightGrey;
        public override string Name => "Giant grey scorpion";

        public override bool Animal => true;
        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Sting, new PoisonAttackEffect(), 1, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "It is a giant grey scorpion. It looks poisonous.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant grey scorpion";
        public override int Hdice => 18;
        public override int Hside => 20;
        public override int LevelFound => 34;
        public override int Mexp => 275;
        public override int NoticeRange => 12;
        public override int Rarity => 4;
        public override int Sleep => 40;
        public override int Speed => 120;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "    grey    ";
        public override string SplitName3 => "  scorpion  ";
        public override bool WeirdMind => true;
    }
}