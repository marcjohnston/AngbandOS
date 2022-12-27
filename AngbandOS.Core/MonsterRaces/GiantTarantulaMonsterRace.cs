using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GiantTarantulaMonsterRace : MonsterRace
    {
        protected GiantTarantulaMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'S';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Giant tarantula";

        public override bool Animal => true;
        public override int ArmourClass => 32;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new BiteAttackType(), new PoisonAttackEffect(), 1, 6),
            new MonsterAttack(new BiteAttackType(), new PoisonAttackEffect(), 1, 6),
            new MonsterAttack(new BiteAttackType(), new PoisonAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "A giant spider with hairy black and red legs.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant tarantula";
        public override int Hdice => 10;
        public override int Hside => 15;
        public override bool ImmunePoison => true;
        public override int LevelFound => 15;
        public override int Mexp => 70;
        public override int NoticeRange => 8;
        public override int Rarity => 3;
        public override int Sleep => 80;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Giant    ";
        public override string SplitName3 => " tarantula  ";
        public override bool WeirdMind => true;
    }
}
