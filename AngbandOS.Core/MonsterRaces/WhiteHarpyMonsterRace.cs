using AngbandOS.Core.AttackEffects;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class WhiteHarpyMonsterRace : MonsterRace
    {
        public override char Character => 'H';
        public override string Name => "White harpy";

        public override bool Animal => true;
        public override int ArmourClass => 17;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 1),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 1),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 2),
        };
        public override string Description => "A flying, screeching bird with a woman's face.";
        public override bool Evil => true;
        public override bool Female => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "White harpy";
        public override int Hdice => 2;
        public override int Hside => 5;
        public override int LevelFound => 2;
        public override int Mexp => 5;
        public override int NoticeRange => 16;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   White    ";
        public override string SplitName3 => "   harpy    ";
    }
}
