// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FrumiousBandersnatchMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(LowerCSymbol);
    public override ColorEnum Color => ColorEnum.BrightOrange;
    
    public override bool Animal => true;
    public override int ArmorClass => 30;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 4),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 4),
        (nameof(StingAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a vast armored centipede with massive mandibles and a spiked tail.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Frumious bandersnatch";
    public override int Hdice => 13;
    public override int Hside => 8;
    public override int LevelFound => 12;
    public override int Mexp => 40;
    public override int NoticeRange => 12;
    public override int Rarity => 2;
    public override int Sleep => 30;
    public override int Speed => 120;
    public override string? MultilineName => "Frumious\nbandersnatch";
    public override bool WeirdMind => true;
}
