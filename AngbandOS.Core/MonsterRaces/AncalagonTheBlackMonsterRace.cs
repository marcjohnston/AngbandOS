using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class AncalagonTheBlackMonsterRace : MonsterRace
    {
        protected AncalagonTheBlackMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheAcidMonsterSpell(),
            new BlindnessMonsterSpell(),
            new ConfuseMonsterSpell(),
            new ScareMonsterSpell(),
            new SummonDragonMonsterSpell(),
            new SummonHiDragonMonsterSpell());
        public override char Character => 'D';
        public override Colour Colour => Colour.Black;
        public override string Name => "Ancalagon the Black";

        public override int ArmourClass => 125;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 5, 12),
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 6, 12),
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 8, 12),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 10, 14)
        };
        public override bool BashDoor => true;
        public override string Description => "'Rushing Jaws' is his name, and death is his game. No dragon of the brood of Glaurung can match him.";
        public override bool Dragon => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Ancalagon the Black";
        public override int Hdice => 75;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 58;
        public override bool Male => true;
        public override int Mexp => 30000;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 3;
        public override int Sleep => 70;
        public override int Speed => 120;
        public override string SplitName1 => " Ancalagon  ";
        public override string SplitName2 => "    the     ";
        public override string SplitName3 => "   Black    ";
        public override bool Unique => true;
    }
}
