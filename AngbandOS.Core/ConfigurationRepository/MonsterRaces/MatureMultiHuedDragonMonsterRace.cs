// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MatureMultiHuedDragonMonsterRace : MonsterRace
{
    protected MatureMultiHuedDragonMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheAcidMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheColdMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheLightningMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheFireMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreathePoisonMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BlindnessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerDSymbol>();
    public override ColourEnum Colour => ColourEnum.Purple;
    public override string Name => "Mature multi-hued dragon";

    public override int ArmourClass => 65;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<ClawAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 10),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<ClawAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 10),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 2, 12),
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "A large dragon, scales shimmering many colours.";
    public override bool Dragon => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Mature multi-hued dragon";
    public override int Hdice => 64;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 38;
    public override int Mexp => 1700;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string SplitName1 => "   Mature   ";
    public override string SplitName2 => " multi-hued ";
    public override string SplitName3 => "   dragon   ";
}