using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class SoldierAntMonsterRace : MonsterRace
    {
        protected SoldierAntMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'a';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Soldier ant";

        public override bool Animal => true;
        public override int ArmourClass => 3;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 2),
        };
        public override bool BashDoor => true;
        public override string Description => "A large ant with powerful mandibles.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Soldier ant";
        public override int Hdice => 2;
        public override int Hside => 5;
        public override int LevelFound => 1;
        public override int Mexp => 3;
        public override int NoticeRange => 10;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Soldier   ";
        public override string SplitName3 => "    ant     ";
        public override bool WeirdMind => true;
    }
}
