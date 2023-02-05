namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BodakMonsterRace : MonsterRace
    {
        protected BodakMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new FireBallMonsterSpell(),
            new FireBoltMonsterSpell(),
            new SummonDemonMonsterSpell());
        public override char Character => 'u';
        public override Colour Colour => Colour.Black;
        public override string Name => "Bodak";

        public override int ArmourClass => 68;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new FireAttackEffect(), 4, 6),
            new MonsterAttack(new HitAttackType(), new FireAttackEffect(), 4, 6),
            new MonsterAttack(new GazeAttackType(), new Exp20AttackEffect(), 0, 0),
        };
        public override bool BashDoor => true;
        public override bool Demon => true;
        public override string Description => "It is a humanoid form composed of flames and hatred.";
        public override bool Evil => true;
        public override bool FireAura => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Bodak";
        public override int Hdice => 35;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 36;
        public override int Mexp => 750;
        public override bool Nonliving => true;
        public override int NoticeRange => 10;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 90;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Bodak    ";
        public override bool TakeItem => true;
    }
}
