// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BlackOozeMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.DrainManaMonsterSpell)
    };

    public override string SymbolName => nameof(LowerJSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override int ArmorClass => 6;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(TouchAttack), nameof(AttackEffectsEnum.AcidAttackEffect), 2, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a strangely moving puddle.";
    public override bool Drop60 => true;
    public override bool EmptyMind => true;
    public override int FreqInate => 11;
    public override int FreqSpell => 11;
    public override string FriendlyName => "Black ooze";
    public override int Hdice => 6;
    public override int Hside => 8;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool KillBody => true;
    public override int LevelFound => 23;
    public override int Mexp => 7;
    public override bool Multiply => true;
    public override int NoticeRange => 10;
    public override bool OpenDoor => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 1;
    public override int Speed => 90;
    public override string? MultilineName => "Black\nooze";
    public override bool Stupid => true;
    public override bool TakeItem => true;
}
