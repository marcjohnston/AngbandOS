using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class RattlesnakeMonsterRace : MonsterRace
    {
        protected RattlesnakeMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'J';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Rattlesnake";

        public override bool Animal => true;
        public override int ArmourClass => 24;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new PoisonAttackEffect(), 2, 5),
        };
        public override bool BashDoor => true;
        public override string Description => "It is recognized by the hard-scaled end of its body that is often rattled to frighten its prey.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Rattlesnake";
        public override int Hdice => 6;
        public override int Hside => 7;
        public override bool ImmunePoison => true;
        public override int LevelFound => 6;
        public override int Mexp => 20;
        public override int NoticeRange => 6;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 1;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "Rattlesnake ";
    }
}
