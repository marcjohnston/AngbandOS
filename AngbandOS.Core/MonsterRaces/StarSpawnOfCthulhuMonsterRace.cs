// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class StarSpawnOfCthulhuMonsterRace : MonsterRace
{
    protected StarSpawnOfCthulhuMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheAcidMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheFireMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheNetherMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<RadiationBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BrainSmashMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<DrainManaMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<MindBlastMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<HealMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonCthuloidMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonMonstersMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonUndeadMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<TeleportSelfMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperUSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightGreen;
    public override string Name => "Star-spawn of Cthulhu";

    public override int ArmourClass => 90;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<PoisonAttackEffect>(), 1, 30),
        new MonsterAttack(new ClawAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<AcidAttackEffect>(), 1, 30),
        new MonsterAttack(new TouchAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<UnPowerAttackEffect>(), 1, 10),
        new MonsterAttack(new CrushAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<UnBonusAttackEffect>(), 2, 33)
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
