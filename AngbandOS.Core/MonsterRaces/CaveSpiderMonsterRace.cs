using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class CaveSpiderMonsterRace : MonsterRace
    {
        protected CaveSpiderMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'S';
        public override Colour Colour => Colour.Black;
        public override string Name => "Cave spider";

        public override bool Animal => true;
        public override int ArmourClass => 16;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "It is a black spider that moves in fits and starts.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Cave spider";
        public override bool Friends => true;
        public override int Hdice => 2;
        public override int Hside => 6;
        public override bool HurtByLight => true;
        public override int LevelFound => 2;
        public override int Mexp => 7;
        public override int NoticeRange => 8;
        public override int Rarity => 1;
        public override int Sleep => 80;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Cave    ";
        public override string SplitName3 => "   spider   ";
        public override bool WeirdMind => true;
    }
}
