// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DarkElvenCultistMonsterRace : MonsterRace
{
    protected DarkElvenCultistMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(ConfuseMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(MagicMissileMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(DarknessMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(HealMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(SummonMonsterMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(SummonSpiderMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerHSymbol));
    public override ColourEnum Colour => ColourEnum.Turquoise;
    public override string Name => "Dark elven cultist";

    public override int ArmourClass => 75;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 7),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 7),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 3, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "A powerful dark elf, with mighty nature-controlling enchantments.";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override bool Female => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Dark elven cultist";
    public override int Hdice => 20;
    public override int Hside => 20;
    public override bool HurtByLight => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 25;
    public override int Mexp => 500;
    public override int NoticeRange => 15;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "    Dark    ";
    public override string SplitName2 => "   elven    ";
    public override string SplitName3 => "  cultist   ";
}
