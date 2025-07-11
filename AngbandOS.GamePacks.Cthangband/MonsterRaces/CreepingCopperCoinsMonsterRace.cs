// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CreepingCopperCoinsMonsterRace : MonsterRaceGameConfiguration
{
    public override string SymbolName => nameof(DollarSignSymbol);
    public override string GoldItemFactoryBindingKey => nameof(Copper2GoldItemFactory);

    public override ColorEnum Color => ColorEnum.Copper;
    
    public override bool Animal => true;
    public override int ArmorClass => 24;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 4),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 2, 4),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a pile of coins.";
    public override bool Drop_1D2 => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Creeping copper coins";
    public override int Hdice => 7;
    public override int Hside => 8;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 4;
    public override int Mexp => 9;
    public override int NoticeRange => 3;
    public override bool OnlyDropGold => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 100;
    public override string? MultilineName => "Creeping\ncopper\ncoins";
}
