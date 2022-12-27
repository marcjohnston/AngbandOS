using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class SlimeMoldMonsterRace : MonsterRace
    {
        protected SlimeMoldMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => ',';
        public override Colour Colour => Colour.Green;
        public override string Name => "Slime mold";

        public override int ArmourClass => 4;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new CrawlAttackType(), new PoisonAttackEffect(), 1, 4),
            new MonsterAttack(new CrawlAttackType(), new EatFoodAttackEffect(), 0, 0),
            new MonsterAttack(new DroolAttackType(), null, 0, 0),
            new MonsterAttack(new DroolAttackType(), null, 0, 0)
        };
        public override string Description => "It is a smallish, slimy, icky, hungry creature.";
        public override bool Drop90 => true;
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Slime mold";
        public override int Hdice => 5;
        public override int Hside => 6;
        public override bool ImmunePoison => true;
        public override bool KillBody => true;
        public override int LevelFound => 2;
        public override int Mexp => 8;
        public override int NoticeRange => 14;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Slime    ";
        public override string SplitName3 => "    mold    ";
        public override bool TakeItem => true;
    }
}
