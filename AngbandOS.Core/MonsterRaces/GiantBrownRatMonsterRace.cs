using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GiantBrownRatMonsterRace : MonsterRace
    {
        public override char Character => 'r';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Giant brown rat";

        public override bool Animal => true;
        public override int ArmourClass => 7;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new PoisonAttackEffect(), 1, 3),
        };
        public override string Description => "It is a very vicious rodent.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant brown rat";
        public override int Hdice => 2;
        public override int Hside => 2;
        public override int LevelFound => 4;
        public override int Mexp => 1;
        public override bool Multiply => true;
        public override int NoticeRange => 8;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "   brown    ";
        public override string SplitName3 => "    rat     ";
    }
}
