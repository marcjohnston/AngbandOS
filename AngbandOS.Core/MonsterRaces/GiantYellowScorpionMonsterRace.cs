using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GiantYellowScorpionMonsterRace : MonsterRace
    {
        public override char Character => 'S';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Giant yellow scorpion";

        public override bool Animal => true;
        public override int ArmourClass => 38;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Sting, new PoisonAttackEffect(), 2, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "It is a giant scorpion with a sharp stinger.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant yellow scorpion";
        public override int Hdice => 12;
        public override int Hside => 8;
        public override int LevelFound => 22;
        public override int Mexp => 60;
        public override int NoticeRange => 12;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "   yellow   ";
        public override string SplitName3 => "  scorpion  ";
        public override bool WeirdMind => true;
    }
}
