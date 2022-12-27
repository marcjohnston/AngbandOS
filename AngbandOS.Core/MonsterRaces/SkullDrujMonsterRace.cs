using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class SkullDrujMonsterRace : MonsterRace
    {
        protected SkullDrujMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BrainSmashMonsterSpell(),
            new CauseMortalWoundsMonsterSpell(),
            new MindBlastMonsterSpell(),
            new NetherBoltMonsterSpell(),
            new PlasmaBoltMonsterSpell(),
            new SlowMonsterSpell(),
            new WaterBallMonsterSpell(),
            new CreateTrapsMonsterSpell(),
            new SummonUndeadMonsterSpell());
        public override char Character => 's';
        public override Colour Colour => Colour.BrightGrey;
        public override string Name => "Skull druj";

        public override int ArmourClass => 120;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new BiteAttackType(), new Exp80AttackEffect(), 4, 4),
            new MonsterAttack(new BiteAttackType(), new ParalyzeAttackEffect(), 4, 4),
            new MonsterAttack(new BiteAttackType(), new LoseIntAttackEffect(), 4, 4),
            new MonsterAttack(new BiteAttackType(), new LoseWisAttackEffect(), 4, 4)
        };
        public override bool ColdBlood => true;
        public override string Description => "A glowing skull possessed by sorcerous power. It need not move, but merely blast you with mighty magic.";
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 1;
        public override int FreqSpell => 1;
        public override string FriendlyName => "Skull druj";
        public override int Hdice => 14;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 55;
        public override int Mexp => 25000;
        public override bool NeverMove => true;
        public override int NoticeRange => 20;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Skull    ";
        public override string SplitName3 => "    druj    ";
        public override bool Undead => true;
    }
}
