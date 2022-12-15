using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class LargeGreySnakeMonsterRace : MonsterRace
    {
        public override char Character => 'J';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Large grey snake";

        public override bool Animal => true;
        public override int ArmourClass => 41;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 5),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 1, 8),
        };
        public override bool BashDoor => true;
        public override string Description => "It is about ten feet long.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Large grey snake";
        public override int Hdice => 6;
        public override int Hside => 8;
        public override int LevelFound => 4;
        public override int Mexp => 14;
        public override int NoticeRange => 6;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 50;
        public override int Speed => 100;
        public override string SplitName1 => "   Large    ";
        public override string SplitName2 => "    grey    ";
        public override string SplitName3 => "   snake    ";
    }
}
