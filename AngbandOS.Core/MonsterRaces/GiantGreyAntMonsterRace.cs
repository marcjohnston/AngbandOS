using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GiantGreyAntMonsterRace : MonsterRace
    {
        public override char Character => 'a';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Giant grey ant";

        public override bool Animal => true;
        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
        };
        public override bool BashDoor => true;
        public override string Description => "It is an ant encased in shaggy grey fur.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant grey ant";
        public override int Hdice => 19;
        public override int Hside => 8;
        public override bool KillBody => true;
        public override int LevelFound => 26;
        public override int Mexp => 90;
        public override int NoticeRange => 10;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "    grey    ";
        public override string SplitName3 => "    ant     ";
        public override bool WeirdMind => true;
    }
}