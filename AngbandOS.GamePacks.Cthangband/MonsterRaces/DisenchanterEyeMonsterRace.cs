// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DisenchanterEyeMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.DrainManaMonsterSpell)
    };

    public override string SymbolName => nameof(LowerESymbol);
    public override ColorEnum Color => ColorEnum.Chartreuse;
    
    public override int ArmorClass => 10;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(GazeAttack), nameof(AttackEffectsEnum.DisenchantAttackEffect), 0, 0),
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override string Description => "A disembodied eye, crackling with magic.";
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Disenchanter eye";
    public override int Hdice => 7;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneFear => true;
    public override int LevelFound => 5;
    public override int Mexp => 20;
    public override bool NeverMove => true;
    public override int NoticeRange => 2;
    public override int Rarity => 2;
    public override bool ResistDisenchant => true;
    public override int Sleep => 10;
    public override int Speed => 100;
    public override string? MultilineName => "Disenchanter\neye";
}
