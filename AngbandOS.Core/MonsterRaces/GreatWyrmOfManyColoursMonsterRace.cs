// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreatWyrmOfManyColoursMonsterRace : MonsterRace
{
    protected GreatWyrmOfManyColoursMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheAcidMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheColdMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheLightningMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheFireMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreathePoisonMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BlindnessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperDSymbol>();
    public override ColourEnum Colour => ColourEnum.Purple;
    public override string Name => "Great Wyrm of Many Colours";

    public override int ArmourClass => 170;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 6, 12),
        new MonsterAttack(new ClawAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 6, 12),
        new MonsterAttack(new ClawAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 6, 12),
        new MonsterAttack(new BiteAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 9, 14)
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "A huge dragon whose scales shimmer in myriad hues.";
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
    public override string FriendlyName => "Great Wyrm of Many Colours";
    public override int Hdice => 52;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 68;
    public override bool LightningAura => true;
    public override int Mexp => 31000;
    public override bool MoveBody => true;
    public override int NoticeRange => 40;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 255;
    public override int Speed => 120;
    public override string SplitName1 => " Great Wyrm ";
    public override string SplitName2 => "  of Many   ";
    public override string SplitName3 => "  Colours   ";
}
