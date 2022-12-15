using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GiantBlackAntMonsterRace : MonsterRace
    {
        public override char Character => 'a';
        public override Colour Colour => Colour.Black;
        public override string Name => "Giant black ant";

        public override bool Animal => true;
        public override int ArmourClass => 20;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "It is about three feet long.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant black ant";
        public override int Hdice => 3;
        public override int Hside => 6;
        public override int LevelFound => 2;
        public override int Mexp => 8;
        public override int NoticeRange => 8;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 80;
        public override int Speed => 110;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "   black    ";
        public override string SplitName3 => "    ant     ";
        public override bool WeirdMind => true;
    }
}
