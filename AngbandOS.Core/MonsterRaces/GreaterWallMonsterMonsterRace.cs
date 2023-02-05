namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GreaterWallMonsterMonsterRace : MonsterRace
    {
        protected GreaterWallMonsterMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => '#';
        public override string Name => "Greater wall monster";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 6),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 6),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 3, 6),
        };
        public override bool BashDoor => true;
        public override bool CharMulti => true;
        public override bool ColdBlood => true;
        public override string Description => "A sentient, moving section of wall.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Greater wall monster";
        public override int Hdice => 15;
        public override int Hside => 40;
        public override bool HurtByRock => true;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 50;
        public override int Mexp => 900;
        public override bool Multiply => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override bool PassWall => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 4;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "  Greater   ";
        public override string SplitName2 => "    wall    ";
        public override string SplitName3 => "  monster   ";
    }
}
