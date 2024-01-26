// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AetherVortexMonsterRace : MonsterRace
{
    protected AetherVortexMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheAcidMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheChaosMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheColdMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheConfusionMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheDarkMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheLightningMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheFireMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheForceMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheGravityMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheInertiaMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheLightMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheNetherMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheNexusMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreathePlasmaMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreathePoisonMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheShardsMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheSoundMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheTimeMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerVSymbol));
    public override ColorEnum Color => ColorEnum.BrightGrey;
    public override string Name => "Aether vortex";

    public override int ArmorClass => 40;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(EngulfAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(ElectricityAttackEffect)), 5, 5),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(EngulfAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(FireAttackEffect)), 3, 3),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(EngulfAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(AcidAttackEffect)), 3, 3),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(EngulfAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(ColdAttackEffect)), 3, 3)
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "An awesome vortex of pure magic, power radiates from its frame.";
    public override bool EmptyMind => true;
    public override bool FireAura => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Aether vortex";
    public override int Hdice => 32;
    public override int Hside => 20;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 55;
    public override bool LightningAura => true;
    public override int Mexp => 4500;
    public override bool Nonliving => true;
    public override int NoticeRange => 100;
    public override bool Powerful => true;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override bool ResistNether => true;
    public override bool ResistNexus => true;
    public override bool ResistPlasma => true;
    public override int Sleep => 0;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Aether   ";
    public override string SplitName3 => "   vortex   ";
}
