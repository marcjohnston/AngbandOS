using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GreatCthulhuMonsterRace : MonsterRace
    {
        protected GreatCthulhuMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheAcidMonsterSpell(),
            new BreatheChaosMonsterSpell(),
            new BreatheConfusionMonsterSpell(),
            new BreatheDarkMonsterSpell(),
            new BreatheDisenchantMonsterSpell(),
            new BreatheDisintegrationMonsterSpell(),
            new BreatheFireMonsterSpell(),
            new BreatheNetherMonsterSpell(),
            new BreatheNexusMonsterSpell(),
            new BreathePlasmaMonsterSpell(),
            new BreathePoisonMonsterSpell(),
            new BreatheRadiationMonsterSpell(),
            new BlindnessMonsterSpell(),
            new BrainSmashMonsterSpell(),
            new ConfuseMonsterSpell(),
            new DrainManaMonsterSpell(),
            new MindBlastMonsterSpell(),
            new ScareMonsterSpell(),
            new DarknessMonsterSpell(),
            new DreadCurseMonsterSpell(),
            new ForgetMonsterSpell(),
            new SummonCthuloidMonsterSpell(),
            new SummonHiUndeadMonsterSpell(),
            new SummonKinMonsterSpell(),
            new SummonReaverMonsterSpell(),
            new TeleportSelfMonsterSpell());
        public override char Character => 'X';
        public override Colour Colour => Colour.Green;
        public override string Name => "Great Cthulhu";

        public override int ArmourClass => 140;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new CrushAttackType(), new HurtAttackEffect(), 50, 4),
            new MonsterAttack(new ClawAttackType(), new UnPowerAttackEffect(), 15, 2),
            new MonsterAttack(new ClawAttackType(), new UnBonusAttackEffect(), 15, 2),
            new MonsterAttack(new TouchAttackType(), new PoisonAttackEffect(), 1, 100)
        };
        public override bool BashDoor => true;
        public override bool Demon => true;
        public override string Description => "This creature is death incarnate. 'A monster of vaguely anthropoid outline, but with an octopus-like head... and long narrow wings behind... A mountain walked or stumbled.'";
        public override bool Drop_1D2 => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool EldritchHorror => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Great Cthulhu";
        public override bool GreatOldOne => true;
        public override int Hdice => 100;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 96;
        public override int Mexp => 62500;
        public override bool MoveBody => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 100;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override bool Regenerate => true;
        public override bool ResistDisenchant => true;
        public override bool ResistNether => true;
        public override bool ResistNexus => true;
        public override bool ResistPlasma => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 100;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Great    ";
        public override string SplitName3 => "  Cthulhu   ";
        public override bool Unique => true;
    }
}
