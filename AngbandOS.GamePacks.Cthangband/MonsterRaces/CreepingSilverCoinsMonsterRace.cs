// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CreepingSilverCoinsMonsterRace : MonsterRaceGameConfiguration
{
    public override string SymbolName => nameof(DollarSignSymbol);
    public override string GoldItemFactoryBindingKey => nameof(Silver2GoldItemFactory);
    public override ColorEnum Color => ColorEnum.Silver;
    
    public override bool Animal => true;
    public override int ArmorClass => 30;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 6),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 2, 6),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a pile of coins, crawling forward on thousands of tiny legs.";
    public override bool Drop_1D2 => true;
    public override bool Drop60 => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Creeping silver coins";
    public override int Hdice => 12;
    public override int Hside => 8;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 6;
    public override int Mexp => 18;
    public override int NoticeRange => 4;
    public override bool OnlyDropGold => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 100;
    public override string? MultilineName => "Creeping\nsilver\ncoins";
}
