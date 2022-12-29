using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class HellcatMonsterRace : MonsterRace
    {
        protected HellcatMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'f';
        public override Colour Colour => Colour.Red;
        public override string Name => "Hellcat";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 5),
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 5),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 8),
        };
        public override string Description => "It is as large as a tiger, its yellow eyes are pupilless.";
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Hellcat";
        public override bool Friends => true;
        public override int Hdice => 9;
        public override int Hside => 8;
        public override bool ImmuneFire => true;
        public override int LevelFound => 12;
        public override int Mexp => 40;
        public override int NoticeRange => 20;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Hellcat   ";
        public override bool WeirdMind => true;
    }
}
