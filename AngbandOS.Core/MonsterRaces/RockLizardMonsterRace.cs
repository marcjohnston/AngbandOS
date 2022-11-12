using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class RockLizardMonsterRace : MonsterRace
    {
        public override char Character => 'R';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Rock lizard";

        public override bool Animal => true;
        public override int ArmourClass => 4;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 1),
        };
        public override string Description => "It is a small lizard with a hardened hide.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Rock lizard";
        public override int Hdice => 3;
        public override int Hside => 4;
        public override int LevelFound => 1;
        public override int Mexp => 2;
        public override int NoticeRange => 20;
        public override int Rarity => 1;
        public override int Sleep => 15;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Rock    ";
        public override string SplitName3 => "   lizard   ";
    }
}
