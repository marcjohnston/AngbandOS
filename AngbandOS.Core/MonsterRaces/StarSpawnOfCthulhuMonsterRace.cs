using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class StarSpawnOfCthulhuMonsterRace : MonsterRace
    {
        protected StarSpawnOfCthulhuMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheAcidMonsterSpell(),
            new BreatheFireMonsterSpell(),
            new BreatheNetherMonsterSpell(),
            new RadiationBallMonsterSpell(),
            new BrainSmashMonsterSpell(),
            new ConfuseMonsterSpell(),
            new DrainManaMonsterSpell(),
            new MindBlastMonsterSpell(),
            new ScareMonsterSpell(),
            new HealMonsterSpell(),
            new SummonCthuloidMonsterSpell(),
            new SummonMonstersMonsterSpell(),
            new SummonUndeadMonsterSpell(),
            new TeleportSelfMonsterSpell());
        public override char Character => 'U';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Star-spawn of Cthulhu";

        public override int ArmourClass => 90;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new PoisonAttackEffect(), 1, 30),
            new MonsterAttack(AttackType.Claw, new AcidAttackEffect(), 1, 30),
            new MonsterAttack(AttackType.Touch, new UnPowerAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Crush, new UnBonusAttackEffect(), 2, 33)
        };
        public override bool BashDoor => true;
        public override bool Cthuloid => true;
        public override string Description => "The last remnants of sanity threaten to leave your brain as you behold this titanic bat-winged, octopus-headed unholy abomination.";
        public override bool Drop_1D2 => true;
        public override bool Drop_2D2 => true;
        public override bool Drop90 => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Star-spawn of Cthulhu";
        public override int Hdice => 75;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool KillItem => true;
        public override int LevelFound => 86;
        public override int Mexp => 44000;
        public override bool Nonliving => true;
        public override int NoticeRange => 90;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override bool ResistNether => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 90;
        public override int Speed => 130;
        public override string SplitName1 => " Star-spawn ";
        public override string SplitName2 => "     of     ";
        public override string SplitName3 => "  Cthulhu   ";
    }
}
