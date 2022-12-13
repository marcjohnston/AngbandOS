using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GiantWhiteLouseMonsterRace : MonsterRace
    {
        public override char Character => 'l';
        public override string Name => "Giant white louse";

        public override bool Animal => true;
        public override int ArmourClass => 5;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 1),
        };
        public override string Description => "It is six inches long.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant white louse";
        public override int Hdice => 1;
        public override int Hside => 1;
        public override int LevelFound => 3;
        public override int Mexp => 1;
        public override bool Multiply => true;
        public override int NoticeRange => 6;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "   white    ";
        public override string SplitName3 => "   louse    ";
        public override bool WeirdMind => true;
    }
}
