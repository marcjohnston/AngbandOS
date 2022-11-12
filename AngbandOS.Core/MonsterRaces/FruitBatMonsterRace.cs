using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class FruitBatMonsterRace : MonsterRace
    {
        public override char Character => 'b';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Fruit bat";

        public override bool Animal => true;
        public override int ArmourClass => 3;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 1),
        };
        public override string Description => "A fast-moving pest.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Fruit bat";
        public override int Hdice => 1;
        public override int Hside => 6;
        public override int LevelFound => 1;
        public override int Mexp => 1;
        public override int NoticeRange => 20;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Fruit    ";
        public override string SplitName3 => "    bat     ";
    }
}
