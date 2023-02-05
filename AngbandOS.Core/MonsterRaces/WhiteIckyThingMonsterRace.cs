namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class WhiteIckyThingMonsterRace : MonsterRace
    {
        protected WhiteIckyThingMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'i';
        public override string Name => "White icky thing";

        public override int ArmourClass => 7;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new TouchAttackType(), new HurtAttackEffect(), 1, 2),
        };
        public override string Description => "It is a smallish, slimy, icky creature.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "White icky thing";
        public override int Hdice => 3;
        public override int Hside => 5;
        public override int LevelFound => 1;
        public override int Mexp => 2;
        public override int NoticeRange => 12;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "   White    ";
        public override string SplitName2 => "    icky    ";
        public override string SplitName3 => "   thing    ";
    }
}
