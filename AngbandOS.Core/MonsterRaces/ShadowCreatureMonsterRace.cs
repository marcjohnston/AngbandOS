namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ShadowCreatureMonsterRace : MonsterRace
    {
        protected ShadowCreatureMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'h';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Shadow creature";

        public override int ArmourClass => 12;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 7),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 7),
        };
        public override bool BashDoor => true;
        public override string Description => "A humanoid creature with extra joints in its extremities.";
        public override bool Drop60 => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Shadow creature";
        public override bool Friends => true;
        public override int Hdice => 9;
        public override int Hside => 8;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 10;
        public override bool Male => true;
        public override int Mexp => 35;
        public override int NoticeRange => 12;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 16;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Shadow   ";
        public override string SplitName3 => "  creature  ";
    }
}
