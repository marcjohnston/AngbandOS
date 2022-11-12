using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GiantFruitFlyMonsterRace : MonsterRace
    {
        public override char Character => 'I';
        public override Colour Colour => Colour.BrightOrange;
        public override string Name => "Giant fruit fly";

        public override bool Animal => true;
        public override int ArmourClass => 14;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 2),
        };
        public override string Description => "A fast-breeding, annoying pest.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant fruit fly";
        public override int Hdice => 2;
        public override int Hside => 2;
        public override int LevelFound => 10;
        public override int Mexp => 4;
        public override bool Multiply => true;
        public override int NoticeRange => 8;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 6;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "   fruit    ";
        public override string SplitName3 => "    fly     ";
        public override bool WeirdMind => true;
    }
}
