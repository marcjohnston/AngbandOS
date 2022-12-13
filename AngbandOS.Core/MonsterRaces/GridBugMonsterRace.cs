using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GridBugMonsterRace : MonsterRace
    {
        public override char Character => 'I';
        public override Colour Colour => Colour.BrightPurple;
        public override string Name => "Grid bug";

        public override bool Animal => true;
        public override int ArmourClass => 2;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new ElectricityAttackEffect(), 1, 4),
        };
        public override string Description => "A strange electric bug.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Grid bug";
        public override bool Friends => true;
        public override int Hdice => 2;
        public override int Hside => 4;
        public override bool ImmuneFear => true;
        public override bool ImmuneLightning => true;
        public override int LevelFound => 1;
        public override int Mexp => 2;
        public override int NoticeRange => 10;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Grid    ";
        public override string SplitName3 => "    bug     ";
        public override bool Stupid => true;
        public override bool WeirdMind => true;
    }
}
