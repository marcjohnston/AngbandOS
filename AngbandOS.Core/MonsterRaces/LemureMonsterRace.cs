namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class LemureMonsterRace : MonsterRace
    {
        protected LemureMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'u';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Lemure";

        public override int ArmourClass => 32;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 8),
        };
        public override bool BashDoor => true;
        public override bool Demon => true;
        public override string Description => "It is the larval form of a major demon.";
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Lemure";
        public override bool Friends => true;
        public override int Hdice => 13;
        public override int Hside => 9;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override int LevelFound => 8;
        public override int Mexp => 16;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Lemure   ";
    }
}
