// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ItMonsterRace : MonsterRace
{
    protected ItMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<ShriekMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BlindnessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<DrainManaMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BlinkMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<CreateTrapsMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<DarknessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ForgetMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<HealMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonHydraMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonMonsterMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonUndeadMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<TeleportAwayMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<TeleportToMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PeriodSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightWhite;
    public override string Name => "It";

    public override int ArmourClass => 80;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<GazeAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<BlindAttackEffect>(), 8, 8),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<TerrifyAttackEffect>(), 0, 0),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<GazeAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<Exp40AttackEffect>(), 0, 0),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<EatItemAttackEffect>(), 0, 0)
    };
    public override bool AttrClear => true;
    public override bool CharClear => true;
    public override bool CharMulti => true;
    public override bool ColdBlood => true;
    public override string Description => "Nobody has ever seen It.";
    public override bool Drop_1D2 => true;
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "It";
    public override int Hdice => 77;
    public override int Hside => 9;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 24;
    public override int Mexp => 400;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override int Rarity => 3;
    public override bool Reflecting => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 25;
    public override bool Smart => true;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "     It     ";
    public override bool Unique => true;
}
