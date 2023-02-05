namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class OlogMonsterRace : MonsterRace
    {
        protected OlogMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'T';
        public override Colour Colour => Colour.Green;
        public override string Name => "Olog";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 12),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 12),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 3),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 3)
        };
        public override bool BashDoor => true;
        public override string Description => "It is a massive intelligent troll with needle sharp fangs.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Olog";
        public override bool Friends => true;
        public override int Hdice => 42;
        public override int Hside => 10;
        public override bool ImmunePoison => true;
        public override int LevelFound => 35;
        public override int Mexp => 400;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 50;
        public override bool Smart => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Olog    ";
        public override bool Troll => true;
    }
}
