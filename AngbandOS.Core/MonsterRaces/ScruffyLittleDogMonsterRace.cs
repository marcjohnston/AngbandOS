using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class ScruffyLittleDogMonsterRace : MonsterRace
    {
        public override char Character => 'C';
        public override Colour Colour => Colour.BrightGrey;
        public override string Name => "Scruffy little dog";

        public override bool Animal => true;
        public override int ArmourClass => 1;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 1),
        };
        public override string Description => "A thin flea-ridden mutt, growling as you get close.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Scruffy little dog";
        public override int Hdice => 1;
        public override int Hside => 3;
        public override int LevelFound => 0;
        public override int Mexp => 0;
        public override int NoticeRange => 20;
        public override bool RandomMove25 => true;
        public override int Rarity => 3;
        public override int Sleep => 5;
        public override int Speed => 110;
        public override string SplitName1 => "  Scruffy   ";
        public override string SplitName2 => "   little   ";
        public override string SplitName3 => "    dog     ";
    }
}