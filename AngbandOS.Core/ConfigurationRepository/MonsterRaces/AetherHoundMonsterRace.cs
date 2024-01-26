// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AetherHoundMonsterRace : MonsterRace
{
    protected AetherHoundMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheAcidMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheChaosMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheColdMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheConfusionMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheDarkMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheDisenchantMonsterSpell)),
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
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperZSymbol));
    public override ColorEnum Color => ColorEnum.BrightGrey;
    public override string Name => "Aether hound";

    public override bool Animal => true;
    public override int ArmorClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 2, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 2, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 2, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 3, 3)
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "A shifting, swirling form. It seems to be all colors and sizes and shapes, though the dominant form is that of a huge dog. You feel very uncertain all of a sudden.";
    public override bool FireAura => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Aether hound";
    public override bool Friends => true;
    public override int Hdice => 60;
    public override int Hside => 30;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 75;
    public override bool LightningAura => true;
    public override int Mexp => 10000;
    public override int NoticeRange => 30;
    public override int Rarity => 2;
    public override bool ResistDisenchant => true;
    public override bool ResistNether => true;
    public override bool ResistNexus => true;
    public override bool ResistPlasma => true;
    public override int Sleep => 0;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Aether   ";
    public override string SplitName3 => "   hound    ";
}
