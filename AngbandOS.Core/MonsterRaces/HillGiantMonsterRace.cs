namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class HillGiantMonsterRace : MonsterRace
    {
        protected HillGiantMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'P';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Hill giant";

        public override int ArmourClass => 45;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 6),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "A ten foot tall humanoid with powerful muscles.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Hill giant";
        public override bool Giant => true;
        public override int Hdice => 16;
        public override int Hside => 10;
        public override int LevelFound => 14;
        public override bool Male => true;
        public override int Mexp => 60;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Hill    ";
        public override string SplitName3 => "   giant    ";
    }
}
