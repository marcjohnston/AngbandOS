// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DisenchanterMoldMonsterRace : MonsterRace
{
    protected DisenchanterMoldMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<DrainManaMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerMSymbol));
    public override ColourEnum Colour => ColourEnum.Chartreuse;
    public override string Name => "Disenchanter mold";

    public override int ArmourClass => 20;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<UnBonusAttackEffect>(), 1, 6),
    };
    public override bool AttrMulti => true;
    public override string Description => "It is a strange glowing growth on the dungeon floor.";
    public override bool EmptyMind => true;
    public override int FreqInate => 11;
    public override int FreqSpell => 11;
    public override string FriendlyName => "Disenchanter mold";
    public override int Hdice => 16;
    public override int Hside => 8;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 10;
    public override int Mexp => 40;
    public override bool NeverMove => true;
    public override int NoticeRange => 2;
    public override int Rarity => 2;
    public override bool ResistDisenchant => true;
    public override int Sleep => 70;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "Disenchanter";
    public override string SplitName3 => "    mold    ";
    public override bool Stupid => true;
}
