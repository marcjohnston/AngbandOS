using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class KillerRedBeetleMonsterRace : Base2MonsterRace
    {
        public override char Character => 'K';
        public override Colour Colour => Colour.Red;
        public override string Name => "Killer red beetle";

        public override bool Animal => true;
        public override int ArmourClass => 45;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 3, 4),
            new MonsterAttack(AttackType.Spit, new FireAttackEffect(), 4, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "It is a giant beetle wreathed in flames.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Killer red beetle";
        public override int Hdice => 13;
        public override int Hside => 8;
        public override bool ImmuneFire => true;
        public override int Level => 27;
        public override int Mexp => 95;
        public override int NoticeRange => 14;
        public override int Rarity => 1;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "   Killer   ";
        public override string SplitName2 => "    red     ";
        public override string SplitName3 => "   beetle   ";
        public override bool WeirdMind => true;
    }
}
