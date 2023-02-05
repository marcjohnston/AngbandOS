namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GiantSlimeMoldMonsterRace : MonsterRace
    {
        protected GiantSlimeMoldMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new ShriekMonsterSpell());
        public override char Character => ',';
        public override Colour Colour => Colour.Green;
        public override string Name => "Giant slime mold";

        public override int ArmourClass => 16;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 8),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 8),
        };
        public override bool BashDoor => true;
        public override string Description => "A pile of rotting vegetation that slides towards you with a disgusting stench, waking all it nears.";
        public override bool Drop90 => true;
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Giant slime mold";
        public override int Hdice => 20;
        public override int Hside => 6;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 18;
        public override int Mexp => 75;
        public override int NoticeRange => 20;
        public override bool OnlyDropGold => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "   slime    ";
        public override string SplitName3 => "    mold    ";
        public override bool Stupid => true;
    }
}
