// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DisenchanterMoldMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.DrainManaMonsterSpell)
    };

    public override string SymbolName => nameof(LowerMSymbol);
    public override ColorEnum Color => ColorEnum.Chartreuse;
    
    public override int ArmorClass => 20;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(TouchAttack), nameof(AttackEffectsEnum.DisenchantAttackEffect), 1, 6),
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
    public override string? MultilineName => "Disenchanter\nmold";
    public override bool Stupid => true;
}
