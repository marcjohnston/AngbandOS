using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class HuntingHawkMonsterRace : MonsterRace
    {
        public override char Character => 'B';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Hunting hawk";

        public override bool Animal => true;
        public override int ArmourClass => 25;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 4),
        };
        public override string Description => "Trained to hunt and kill without fear.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Hunting hawk";
        public override int Hdice => 8;
        public override int Hside => 8;
        public override bool ImmuneFear => true;
        public override int LevelFound => 8;
        public override int Mexp => 22;
        public override int NoticeRange => 30;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Hunting   ";
        public override string SplitName3 => "    hawk    ";
    }
}