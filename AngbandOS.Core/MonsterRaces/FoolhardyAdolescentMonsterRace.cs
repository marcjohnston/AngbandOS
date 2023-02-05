namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class FoolhardyAdolescentMonsterRace : MonsterRace
    {
        protected FoolhardyAdolescentMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 't';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Foolhardy adolescent";

        public override int ArmourClass => 15;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "He wants to kill a hero to prove that he's hard.";
        public override bool Drop90 => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Foolhardy adolescent";
        public override int Hdice => 3;
        public override int Hside => 6;
        public override int LevelFound => 0;
        public override bool Male => true;
        public override int Mexp => 0;
        public override int NoticeRange => 50;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 4;
        public override int Sleep => 4;
        public override int Speed => 109;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " Foolhardy  ";
        public override string SplitName3 => " adolescent ";
        public override bool TakeItem => true;
    }
}
