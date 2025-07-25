// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CreepingMithrilCoinsMonsterRace : MonsterRaceGameConfiguration
{
    public override string SymbolName => nameof(DollarSignSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string GoldItemFactoryBindingKey => nameof(MithrilGoldItemFactory);

    public override bool Animal => true;
    public override int ArmorClass => 50;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 5),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 3, 5),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a pile of coins, shambling forward on thousands of tiny legs.";
    public override bool Drop_2D2 => true;
    public override bool Drop90 => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Creeping mithril coins";
    public override int Hdice => 20;
    public override int Hside => 8;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 13;
    public override int Mexp => 45;
    public override int NoticeRange => 5;
    public override bool OnlyDropGold => true;
    public override int Rarity => 4;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "Creeping\nmithril\ncoins";
}
