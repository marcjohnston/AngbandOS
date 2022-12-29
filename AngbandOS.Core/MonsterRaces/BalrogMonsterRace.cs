using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class BalrogMonsterRace : MonsterRace
    {
        protected BalrogMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheFireMonsterSpell(),
            new BlindnessMonsterSpell(),
            new BrainSmashMonsterSpell(),
            new ConfuseMonsterSpell(),
            new NetherBallMonsterSpell(),
            new PlasmaBoltMonsterSpell(),
            new SummonDemonMonsterSpell(),
            new SummonHiUndeadMonsterSpell(),
            new SummonUndeadMonsterSpell());
        public override char Character => 'U';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Balrog";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new FireAttackEffect(), 2, 6),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 5, 6),
            new MonsterAttack(new HitAttackType(), new FireAttackEffect(), 6, 2),
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 6, 5)
        };
        public override bool BashDoor => true;
        public override bool Demon => true;
        public override string Description => "It is a massive humanoid demon wreathed in flames.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool FireAura => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Balrog";
        public override int Hdice => 30;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override bool KillWall => true;
        public override int LevelFound => 50;
        public override int Mexp => 10000;
        public override bool MoveBody => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 3;
        public override int Sleep => 80;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Balrog   ";
    }
}
