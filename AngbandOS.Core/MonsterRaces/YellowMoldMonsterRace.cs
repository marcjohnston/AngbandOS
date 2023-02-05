namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class YellowMoldMonsterRace : MonsterRace
    {
        protected YellowMoldMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'm';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Yellow mold";

        public override int ArmourClass => 10;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 4),
        };
        public override string Description => "It is a strange growth on the dungeon floor.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Yellow mold";
        public override int Hdice => 8;
        public override int Hside => 8;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 3;
        public override int Mexp => 9;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 1;
        public override int Sleep => 99;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Yellow   ";
        public override string SplitName3 => "    mold    ";
        public override bool Stupid => true;
    }
}
