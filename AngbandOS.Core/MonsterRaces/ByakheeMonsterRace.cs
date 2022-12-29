using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class ByakheeMonsterRace : MonsterRace
    {
        protected ByakheeMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new ConfuseMonsterSpell(),
            new FireBoltMonsterSpell(),
            new SummonDemonMonsterSpell());
        public override char Character => 'B';
        public override Colour Colour => Colour.Black;
        public override string Name => "Byakhee";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new ClawAttackType(), new LoseStrAttackEffect(), 3, 4),
            new MonsterAttack(new BiteAttackType(), new Exp20AttackEffect(), 3, 4),
        };
        public override bool BashDoor => true;
        public override bool Demon => true;
        public override string Description => "Hybrid demon birds: 'not altogether crows, nor moles, nor buzzards, nor ants, nor decomposed human beings...'";
        public override bool Drop_2D2 => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Byakhee";
        public override bool Friends => true;
        public override int Hdice => 40;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 41;
        public override int Mexp => 1500;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 3;
        public override int Sleep => 80;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Byakhee   ";
    }
}
