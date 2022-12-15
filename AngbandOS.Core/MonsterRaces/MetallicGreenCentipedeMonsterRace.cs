using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class MetallicGreenCentipedeMonsterRace : MonsterRace
    {
        public override char Character => 'c';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Metallic green centipede";

        public override bool Animal => true;
        public override int ArmourClass => 4;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crawl, new HurtAttackEffect(), 1, 1),
        };
        public override bool BashDoor => true;
        public override string Description => "It is about four feet long and carnivorous.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Metallic green centipede";
        public override int Hdice => 4;
        public override int Hside => 4;
        public override int LevelFound => 2;
        public override int Mexp => 3;
        public override int NoticeRange => 5;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "  Metallic  ";
        public override string SplitName2 => "   green    ";
        public override string SplitName3 => " centipede  ";
        public override bool WeirdMind => true;
    }
}
