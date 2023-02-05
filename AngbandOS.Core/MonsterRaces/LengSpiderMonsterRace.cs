namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class LengSpiderMonsterRace : MonsterRace
    {
        protected LengSpiderMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlindnessMonsterSpell(),
            new MindBlastMonsterSpell(),
            new ScareMonsterSpell(),
            new SlowMonsterSpell(),
            new HasteMonsterSpell(),
            new HealMonsterSpell(),
            new SummonSpiderMonsterSpell());
        public override char Character => 'S';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Leng spider";

        public override int ArmourClass => 68;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 4, 3),
            new MonsterAttack(new BiteAttackType(), new PoisonAttackEffect(), 3, 10),
        };
        public override bool BashDoor => true;
        public override bool Cthuloid => true;
        public override string Description => "'There were scenes of old wars, wherein Leng's almost-humans fought with the bloated purple spiders of neighbouring vales.' H.P.Lovecraft - 'The Dream Quest of Unknown Kadath'";
        public override bool Drop_1D2 => true;
        public override bool Drop_2D2 => true;
        public override bool EldritchHorror => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Leng spider";
        public override int Hdice => 45;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 33;
        public override int Mexp => 400;
        public override bool MoveBody => true;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 6;
        public override bool Reflecting => true;
        public override int Sleep => 255;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Leng    ";
        public override string SplitName3 => "   spider   ";
        public override bool TakeItem => true;
    }
}
