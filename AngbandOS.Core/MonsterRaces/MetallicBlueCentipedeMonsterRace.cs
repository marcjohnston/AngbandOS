using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class MetallicBlueCentipedeMonsterRace : MonsterRace
    {
        public override char Character => 'c';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Metallic blue centipede";

        public override bool Animal => true;
        public override int ArmourClass => 6;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crawl, new HurtAttackEffect(), 1, 2),
        };
        public override bool BashDoor => true;
        public override string Description => "It is about four feet long and carnivorous.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Metallic blue centipede";
        public override int Hdice => 4;
        public override int Hside => 5;
        public override int LevelFound => 3;
        public override int Mexp => 7;
        public override int NoticeRange => 6;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 15;
        public override int Speed => 120;
        public override string SplitName1 => "  Metallic  ";
        public override string SplitName2 => "    blue    ";
        public override string SplitName3 => " centipede  ";
        public override bool WeirdMind => true;
    }
}
