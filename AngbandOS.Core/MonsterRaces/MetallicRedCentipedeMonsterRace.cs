using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class MetallicRedCentipedeMonsterRace : MonsterRace
    {
        protected MetallicRedCentipedeMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'c';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Metallic red centipede";

        public override bool Animal => true;
        public override int ArmourClass => 9;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crawl, new HurtAttackEffect(), 1, 2),
        };
        public override bool BashDoor => true;
        public override string Description => "It is about four feet long and carnivorous.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Metallic red centipede";
        public override int Hdice => 4;
        public override int Hside => 8;
        public override int LevelFound => 3;
        public override int Mexp => 12;
        public override int NoticeRange => 8;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "  Metallic  ";
        public override string SplitName2 => "    red     ";
        public override string SplitName3 => " centipede  ";
        public override bool WeirdMind => true;
    }
}
