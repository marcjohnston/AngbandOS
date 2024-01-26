// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreatCthulhuMonsterRace : MonsterRace
{
    protected GreatCthulhuMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheAcidMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheChaosMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheConfusionMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheDarkMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheDisenchantMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheDisintegrationMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheFireMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheNetherMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheNexusMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreathePlasmaMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreathePoisonMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheRadiationMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BlindnessMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BrainSmashMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(ConfuseMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(DrainManaMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(MindBlastMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(ScareMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(DarknessMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(DreadCurseMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(ForgetMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(SummonCthuloidMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(SummonHiUndeadMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(SummonKinMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(SummonReaverMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(TeleportSelfMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperXSymbol));
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "Great Cthulhu";

    public override int ArmorClass => 140;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(CrushAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 50, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(UnPowerAttackEffect)), 15, 2),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(UnBonusAttackEffect)), 15, 2),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(TouchAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(PoisonAttackEffect)), 1, 100)
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
