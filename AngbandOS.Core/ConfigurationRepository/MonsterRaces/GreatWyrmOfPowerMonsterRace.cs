// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreatWyrmOfPowerMonsterRace : MonsterRace
{
    protected GreatWyrmOfPowerMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheAcidMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheChaosMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheColdMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheConfusionMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheDarkMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheDisenchantMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheDisintegrationMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheLightningMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheFireMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheForceMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheGravityMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheInertiaMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheLightMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheManaMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheNetherMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheNexusMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreathePlasmaMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreathePoisonMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheRadiationMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheShardsMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheSoundMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheTimeMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonDragonMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonHiDragonMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonKinMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperDSymbol>();
    public override ColourEnum Colour => ColourEnum.Yellow;
    public override string Name => "Great Wyrm of Power";

    public override int ArmourClass => 111;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<CrushAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<PoisonAttackEffect>(), 8, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<CrushAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<FireAttackEffect>(), 8, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<CrushAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<ElectricityAttackEffect>(), 8, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<CrushAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 10, 18)
    };
    public override bool BashDoor => true;
    public override string Description => "The mightiest of all dragonkind, a great wyrm of power is seldom encountered in our world. It can crush stars with its might.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Great Wyrm of Power";
    public override bool Good => true;
    public override int Hdice => 111;
    public override int Hside => 111;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 90;
    public override bool LightningAura => true;
    public override int Mexp => 47500;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 4;
    public override bool Reflecting => true;
    public override bool ResistDisenchant => true;
    public override bool ResistNether => true;
    public override bool ResistNexus => true;
    public override bool ResistPlasma => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 70;
    public override int Speed => 130;
    public override string SplitName1 => "   Great    ";
    public override string SplitName2 => "  Wyrm of   ";
    public override string SplitName3 => "   Power    ";
}