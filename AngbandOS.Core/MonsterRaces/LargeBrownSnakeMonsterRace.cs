using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class LargeBrownSnakeMonsterRace : MonsterRace
    {
        protected LargeBrownSnakeMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'J';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Large brown snake";

        public override bool Animal => true;
        public override int ArmourClass => 35;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 3),
            new MonsterAttack(new CrushAttackType(), new HurtAttackEffect(), 1, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "It is about eight feet long.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Large brown snake";
        public override int Hdice => 4;
        public override int Hside => 6;
        public override int LevelFound => 1;
        public override int Mexp => 3;
        public override int NoticeRange => 4;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 99;
        public override int Speed => 100;
        public override string SplitName1 => "   Large    ";
        public override string SplitName2 => "   brown    ";
        public override string SplitName3 => "   snake    ";
    }
}
